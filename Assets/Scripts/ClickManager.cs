using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickManager : MonoBehaviour
{
    public Camera camera;
    public GameObject character;
    public Character characterScript;
    
    //navmesh agent
    private NavMeshAgent agent;

    void Start()
    {
        agent = character.GetComponent<NavMeshAgent>();
        SelectedCharacter.Instance.OnSelectedCharacterChange+= OnSelectedCharacterChange;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // draw hit
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red,5f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ore"))
                {
                    SelectedCharacter.Instance.SetLastSelected(hit.collider.gameObject);
                    characterScript.SetCurrentWorkableObject(hit.collider.gameObject.GetComponent<IWorkable>());
                    characterScript.WorkOnCurrentObject();
                }
                else if (hit.transform.gameObject.CompareTag("Character"))
                {
                    Debug.Log("Character selected");
                    SelectedCharacter.Instance.SetLastSelected(hit.collider.gameObject);
                    SelectedCharacter.Instance.SetSelectedCharacter(hit.collider.gameObject);
                }
            }
            
        }
    }

    private void OnSelectedCharacterChange(GameObject selectedCharacter)
    {
        
        character = selectedCharacter;
        agent = character.GetComponent<NavMeshAgent>();
        characterScript = character.GetComponent<Character>();
    }

}
