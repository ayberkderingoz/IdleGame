using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkableObject : MonoBehaviour,IWorkable
{
        protected int maxWorkers;
        protected int currentWorkers = 0;
        protected MaterialType rewardType;
        protected bool isWorking = false;

        protected float workingTime = 3f;
        
        
        //TODO:add workers list
        
        //worker list 
        public List<GameObject> workers = new List<GameObject>();
        
        
        protected Dictionary<Vector3, GameObject> workerPositions = new Dictionary<Vector3, GameObject>();
        protected Vector3[] availablePositions = new Vector3[]
        {
            new Vector3(0, 0, 2),  
            new Vector3(2, 0, 0),  
            new Vector3(0, 0, -2), 
            new Vector3(-2, 0, 0) 
        };
        
        void Start()
        {
            foreach (var position in availablePositions)
            {
                workerPositions.Add(position, null);
            }
        }
        public bool CanWorkOn(GameObject worker) //TODO: heryerde bunu call etmek yerine bir kere call worker inputa gerek yok galiba
        {
            if(MaxWorkers > CurrentWorkers)
            {
                return true;
            }

            return false;
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
            }
    
            availablePosition = Vector3.zero;
            return false;
        }

    
        public void StartWorking(GameObject worker)
        {
            AddWorker(worker);
            isWorking = true;
            StartCoroutine(Work());
            
        }
    
        public void StopWorking(GameObject worker)
        {
            
            isWorking = false; //TODO: check if there are other workers
            StopCoroutine(Work());
            RemoveWorker(worker);
        }
    
        public GameObject GetGameObject()
        {
            return gameObject;
        }
    
        public int MaxWorkers => maxWorkers;
    
        public int CurrentWorkers => currentWorkers;
        
        
        public IEnumerator Work()
        {
            while (isWorking)
            {
                yield return new WaitForSeconds(workingTime);
                InventoryManager.Instance.AddItem(rewardType, 1);
            }
        }


        private void AddWorker(GameObject worker)
        {
            foreach (var pair in workerPositions)
            {
                if (pair.Value == null)
                {
                    currentWorkers++;
                    workers.Add(worker);
                    workerPositions[pair.Key] = worker;
                    break;
                    
                }
            }
            
        }
        private void RemoveWorker(GameObject worker)
        {
            workers.Remove(worker);
            currentWorkers--;
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

