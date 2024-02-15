using System;
using Recruit;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private IWorkable currentWorkableObject;
    public GameObject currentWorkableObjectGameObject;
    
    public Stats stats;
    private PooledObject _pooledObject;

    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (currentWorkableObject != null)
        {
            
        }
    }
    

    public void WorkOnCurrentObject()
    {
        if (currentWorkableObject != null)
        {
            if (currentWorkableObject.IsPositionAvailable(out var desiredPosition))
            {
                
                MoveCharacter(desiredPosition, currentWorkableObject.GetGameObject());
                currentWorkableObject.StartWorking(this,gameObject);
            }
        }
        //TODO: Implement else methods for when the character cannot work on the current workable object
    }

    private void MoveCharacter(Vector3 desiredPosition,GameObject workableObject)
    {
        _agent.SetDestination(desiredPosition);
        transform.LookAt(workableObject.transform);
    }

    public void SetCurrentWorkableObject(IWorkable workableObject)
    {
        if (currentWorkableObject != null)
        {
            currentWorkableObject.StopWorking(this,gameObject);
        }
        currentWorkableObject = workableObject;
        currentWorkableObjectGameObject = currentWorkableObject.GetGameObject();
    }



    public void SetCharacter(Stats stats, PooledObject pooledObject)
    {
        this.stats = stats;
        _pooledObject = pooledObject;
        PrintStats(); //TODO: will be removed
    }

    private void PrintStats()
    {
        Debug.Log("Mine: " + stats.mineLevel);
        Debug.Log("Wood: " + stats.woodLevel);
        Debug.Log("Farm: " + stats.farmLevel);
        Debug.Log("Engineering: " + stats.engineeringLevel);
        Debug.Log("Damage: " + stats.damageLevel);
    }

}