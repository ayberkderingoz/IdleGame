using UnityEngine;

public class Rock : MonoBehaviour, IWorkable,IMineable
{
    public int maxWorkers = 3;
    private int currentWorkers = 0;
    
    //TODO:add workers list
    

    
    private Vector3[] availablePositions = new Vector3[]
    {
        new Vector3(0, 0, 2),  
        new Vector3(2, 0, 0),  
        new Vector3(0, 0, -2), 
        new Vector3(-2, 0, 0) 
    };

    public bool CanWorkOn(GameObject worker)
    {
        //TODO: Check if worker has skill to work on this rock
        return true;
    }

    public bool IsPositionAvailable(out Vector3 availablePosition)
    {
        if (currentWorkers < maxWorkers)
        {
            foreach (var position in availablePositions)
            {
                Vector3 potentialPosition = transform.position + position;

                if (!IsPositionOccupied(potentialPosition))
                {
                    availablePosition = potentialPosition;
                    return true;
                }
            }
        }

        availablePosition = Vector3.zero;
        return false;
    }

    public bool IsPositionOccupied(Vector3 position)
    {
        
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
        if (CanWorkOn(worker) && IsPositionAvailable(out Vector3 availablePosition))
        {
            currentWorkers++;
            Mine();
        }
    }

    public void StopWorking(GameObject worker)
    {
        
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
}
