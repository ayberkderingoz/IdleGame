using System;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private IWorkable currentWorkableObject;
    public GameObject currentWorkableObjectGameObject;

    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (currentWorkableObject != null)
        {
            //WorkOnCurrentObject();
        }
    }

    public void WorkOnCurrentObject()
    {
        if (currentWorkableObject != null && currentWorkableObject.CanWorkOn(gameObject))
        {
            if (currentWorkableObject.IsPositionAvailable(out var desiredPosition))
            {
                
                MoveCharacter(desiredPosition, currentWorkableObject.GetGameObject());
                currentWorkableObject.StartWorking(gameObject);
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
            currentWorkableObject.StopWorking(gameObject);
        }
        currentWorkableObject = workableObject;
        currentWorkableObjectGameObject = currentWorkableObject.GetGameObject();
    }

}