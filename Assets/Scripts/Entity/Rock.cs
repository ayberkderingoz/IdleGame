using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IWorkable,IMineable
{
    public int maxWorkers = 3;
    private int currentWorkers = 0;
    
    //TODO:add workers list
    
    //worker list 
    private List<GameObject> workers = new List<GameObject>();
    
    
    private Dictionary<Vector3, GameObject> workerPositions = new Dictionary<Vector3, GameObject>();
    private Vector3[] availablePositions = new Vector3[]
    {
        new Vector3(0, 0, 2),  
        new Vector3(2, 0, 0),  
        new Vector3(0, 0, -2), 
        new Vector3(-2, 0, 0) 
    };
    
    void Awake()
    {
        foreach (var position in availablePositions)
        {
            workerPositions.Add(position, null);
        }
    }
    public bool CanWorkOn(GameObject worker)
    {
        //TODO: Check if worker has skill to work on this rock
        return true;
    }

    public bool IsPositionAvailable(out Vector3 availablePosition)
    {
        if (currentWorkers < maxWorkers)
        {
            foreach (var pos in workerPositions)
            {
                if (pos.Value == null)
                {
                    Vector3 potentialPosition = transform.position + pos.Key;
                    availablePosition = potentialPosition;
                    return true;
                }
            }
            /*foreach (var position in availablePositions)
            {
                Vector3 potentialPosition = transform.position + position;

                if (!IsPositionOccupied(potentialPosition))
                {
                    availablePosition = potentialPosition;
                    return true;
                }
            }*/
        }

        availablePosition = Vector3.zero;
        return false;
    }

    public bool IsPositionOccupied(Vector3 position)
    {
        /*
         * Function deprecated do not use
         */
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Character"))
            {
                return true;
            }
        }

        return false;
    }

    public void StartWorking(GameObject worker)
    {
        if (CanWorkOn(worker))
        {
            currentWorkers++;
            AddWorker(worker);
            Mine();
        }
    }

    public void StopWorking(GameObject worker)
    {
        RemoveWorker(worker);
        currentWorkers--;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public int MaxWorkers => maxWorkers;

    public int CurrentWorkers => currentWorkers;
    public void Mine()
    {
        Debug.Log("Mining");
    }
    
    private void AddWorker(GameObject worker)
    {
        workers.Add(worker);
        foreach (var pair in workerPositions)
        {
            if (pair.Value == null)
            {
                workerPositions[pair.Key] = worker;
                break;
            }
        }
    }
    private void RemoveWorker(GameObject worker)
    {
        workers.Remove(worker);
        foreach (var pair in workerPositions)
        {
            if (pair.Value == worker)
            {
                workerPositions[pair.Key] = null;
                break;
            }
        }
    }
    
    
    
}
