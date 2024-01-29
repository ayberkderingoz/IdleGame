using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ObjectToPool
{
    public PooledObjectType type;
    public GameObject gameObject;
    public int amount;
    public Transform parent;
}

[Serializable]
public class PooledObject
{
    public GameObject gameObject;
    public Transform transform;
    public PooledObjectType type;

    public void ReturnToPool()
    {
        ObjectPool.Instance.TakeBack(this);
    }
    public void ReturnToPoolDelayed(float time)
    {
        ObjectPool.Instance.TakeBackDelayed(this, time);
    }
}

[Serializable]
public enum PooledObjectType
{
    Character
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public List<ObjectToPool> objectToPool;
    public Queue<PooledObject> PooledObjectsQ;
    public Dictionary<PooledObjectType, Queue<PooledObject>> PoolDictionary;

    public bool isPoolSet;

    private void Awake()
    {
        Instance = this;
        StartPool();
    }

    private void StartPool()
    {
        PoolDictionary = new Dictionary<PooledObjectType, Queue<PooledObject>>();
        foreach (var item in objectToPool)
        {
            PooledObjectsQ = new Queue<PooledObject>();
            for (var i = 0; i < item.amount; i++)
            {
                var obj = Instantiate(item.gameObject, item.parent);
                obj.name = item.type.ToString();
                obj.SetActive(false);

                PooledObjectsQ.Enqueue(new PooledObject()
                {
                    gameObject = obj,
                    transform = obj.transform,
                    type = item.type
                });
            }

            PoolDictionary.Add(item.type, PooledObjectsQ);
        }

        isPoolSet = true;
    }


    public PooledObject GetPooledObject(PooledObjectType type, bool setActive = false)
    {
        if (!PoolDictionary.ContainsKey(type))
        {
            return null;
        }

        var obj = PoolDictionary[type].Dequeue();
        if (obj.gameObject.activeSelf)
            return GetPooledObject(type);

        var prefabRotation = objectToPool.First(x => x.type == type).gameObject.transform.rotation;
        obj.transform.rotation = prefabRotation;
        obj.transform.localScale = objectToPool.First(x => x.type == type).gameObject.transform.localScale;
        obj.gameObject.SetActive(setActive);
        return obj;
    }

    public void TakeBack(PooledObject obj)
    {
        if (!gameObject.activeSelf) return;
        if (obj.gameObject == null) return;

        obj.gameObject.SetActive(false);
        var objectType = obj.type;
        PoolDictionary[objectType].Enqueue(obj);
    }
    public void TakeBackDelayed(PooledObject pooledObject, float time)
    {
        StartCoroutine(TakeBackDelayedCoroutine(pooledObject, time));
    }

    private IEnumerator TakeBackDelayedCoroutine(PooledObject pooledObject, float time)
    {
        yield return new WaitForSeconds(time);
        TakeBack(pooledObject);
    }
}