using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Entity;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    private Camera _camera;
    private GameObject character;
    private Character characterScript;


    void Start()
    {
        _camera = Camera.main;
        SelectedCharacter.Instance.OnSelectedCharacterChange+= OnSelectedCharacterChange;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current) {position = mousePosition}, results);
            if (Helpers.IsPointerOverUIElement(results))
            {
                return;
            }
            // draw hit
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red,5f);
            if (Physics.Raycast(ray, out hit))
            {
                
                
                if (hit.collider.gameObject.CompareTag("Workable"))
                {
                    if (character == null)
                    {
                        return;
                    }
                    var workable = hit.collider.gameObject.GetComponent<IWorkable>();
                    SelectedCharacter.Instance.SetLastSelected(hit.collider.gameObject);
                    if (!workable.CanWorkOn(character)) return;
                    characterScript.SetCurrentWorkableObject(workable);
                    characterScript.WorkOnCurrentObject();
                }
                else if (hit.transform.gameObject.CompareTag("Character"))
                {
                    Debug.Log("Character selected");
                    SelectedCharacter.Instance.SetLastSelected(hit.collider.gameObject);
                    SelectedCharacter.Instance.SetSelectedCharacter(hit.collider.gameObject);
                }
                else if (hit.transform.gameObject.CompareTag("Depositable"))
                {
                    var depositable = hit.collider.gameObject.GetComponent<DepositableObject>();
                    depositable.OpenRepairMenu();
                    
                }
            }
            
        }
    }

    private void OnSelectedCharacterChange(GameObject selectedCharacter)
    {
        character = selectedCharacter;
        characterScript = character.GetComponent<Character>();
    }

}
