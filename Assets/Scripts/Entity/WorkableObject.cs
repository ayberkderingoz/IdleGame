using System.Collections;
using System.Collections.Generic;
using Recruit;
using UnityEngine;

public abstract class WorkableObject : MonoBehaviour, IWorkable
{
    //TODO:add workers list

    //worker list 
    public List<GameObject> workers = new();

    protected Vector3[] availablePositions =
    {
        new(0, 0, 2),
        new(2, 0, 0),
        new(0, 0, -2),
        new(-2, 0, 0)
    };

    protected int currentWorkers;
    protected bool isUsingMaterial = false;
    protected bool isWorking;
    protected MaterialType materialUsed = MaterialType.None;
    protected int maxWorkers;
    protected MaterialType rewardType;


    protected Dictionary<Vector3, GameObject> workerPositions = new();
    protected float workingTime = 3f;
    protected Dictionary<Character, Coroutine> jobs = new();
    

    private void Start()
    {
        foreach (var position in availablePositions) workerPositions.Add(position, null);
    }

    public bool CanWorkOn(GameObject worker) //TODO: heryerde bunu call etmek yerine bir kere call worker inputa gerek yok galiba
    {
        if(workers.Contains(worker)) return true;
        if (MaxWorkers > CurrentWorkers) return true;

        return false;
    }

    public bool IsPositionAvailable(out Vector3 availablePosition)
    {
        if (currentWorkers < maxWorkers)
            foreach (var pos in workerPositions)
                if (pos.Value == null)
                {
                    var potentialPosition = transform.position + pos.Key;
                    availablePosition = potentialPosition;
                    return true;
                }

        availablePosition = Vector3.zero;
        return false;
    }


    public void StartWorking(Character character,GameObject worker)
    {
        AddWorker(worker);
        isWorking = true;
        jobs[character] = StartCoroutine(Work(character.stats));
    }

    public void StopWorking(Character character,GameObject worker)
    {
        if(jobs.TryGetValue(character, out var routine) && routine != null)
        {
            RemoveWorker(worker);
            isWorking = currentWorkers > 0;
            StopCoroutine(routine);
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public int MaxWorkers => maxWorkers;

    public int CurrentWorkers => currentWorkers;
    public Dictionary<Character, Coroutine> Jobs => jobs;


    public virtual IEnumerator Work(Stats stats)
    {
        while (isWorking)
        {
            yield return new WaitForSeconds(workingTime);

            if (isUsingMaterial)
            {
                if (!InventoryManager.Instance.HasEnoughItem(materialUsed, 1)) continue;
                //TODO: Implemenet a logic that if player does not have enough item maybe character goes idle position or something
                InventoryManager.Instance.RemoveItem(materialUsed, 1);
                InventoryManager.Instance.AddItem(rewardType, 1);
            }
            else
            {
                InventoryManager.Instance.AddItem(rewardType, 1);
            }
        }
    }


    private void AddWorker(GameObject worker)
    {
        foreach (var pair in workerPositions)
            if (pair.Value == null)
            {
                currentWorkers++;
                workers.Add(worker);
                workerPositions[pair.Key] = worker;
                break;
            }
    }

    private void RemoveWorker(GameObject worker)
    {
        workers.Remove(worker);
        currentWorkers--;
        foreach (var pair in workerPositions)
            if (pair.Value == worker)
            {
                workerPositions[pair.Key] = null;
                break;
            }
    }
}