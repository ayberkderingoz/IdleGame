using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    //singleton
    private static SelectedCharacter _instance;
    public static SelectedCharacter Instance => _instance;

    public GameObject selectedCharacter;
    public GameObject lastSelected;

    public Action<GameObject> OnSelectedCharacterChange;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    
    public void SetSelectedCharacter(GameObject character)
    {
        selectedCharacter = character;
        OnSelectedCharacterChange?.Invoke(selectedCharacter);
    }
    public void SetLastSelected(GameObject gameObj)
    {
        if (lastSelected != gameObj)
        {
            //TODO: düzenle bunu
            HighlightLastSelected(Color.white);
            lastSelected = gameObj;
            HighlightLastSelected(Color.red);
        }
    }
    
    //highlight selected character functon
    public void HighlightLastSelected(Color color) //TODO: will be removed, here fur debugging purposes
    {
        if (lastSelected != null && (lastSelected.CompareTag("Workable") || lastSelected.CompareTag("Depositable")||lastSelected.CompareTag("Repairable")))
        {
            var selectedCharacterRenderer = lastSelected.GetComponent<Renderer>();
            selectedCharacterRenderer.material.color = color;
        }
        else if(lastSelected != null && lastSelected.CompareTag("Character"))
        {
            if(color == Color.red)
                lastSelected.GetComponent<CharacterSkinController>().SetSkinColor(CharacterColor.Black);
            else if(color == Color.white)
                lastSelected.GetComponent<CharacterSkinController>().SetSkinColor(CharacterColor.Red);

        }
    }
    
}
