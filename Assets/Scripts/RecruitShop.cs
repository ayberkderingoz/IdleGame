using System;
using System.Collections;
using System.Collections.Generic;
using Recruit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecruitShop : MonoBehaviour
{
    [SerializeField] private RecruitPanel firstRecruitPanel;
    [SerializeField] private RecruitPanel secondRecruitPanel;
    [SerializeField] private RecruitPanel thirdRecruitPanel;
    
    
    [SerializeField] private Image commonRecruitImage;
    [SerializeField] private Image rareRecruitImage;
    [SerializeField] private Image epicRecruitImage;
    [SerializeField] private Image legendaryRecruitImage;
    
    [SerializeField] private Button firstRecruitButton;
    [SerializeField] private Button secondRecruitButton;
    [SerializeField] private Button thirdRecruitButton;

    [SerializeField] private GameObject recruitConfirmPanel;
    
    

    
    const string timerPrefix = "Next Recruit in: ";
    [SerializeField] private TextMeshProUGUI timerText;
    
    
    
    //recruit timer
    private float refreshTimer;
    [SerializeField] private float refreshTimerMax = 300f;

    private List<Recruitable> recruitables;



    
    private int selectedRecruitIndex;

    
    
    //every 5 min refresh recruit list
    private void Start()
    {
        RefreshRecruitList();
        refreshTimer = refreshTimerMax;
    }
    
    private void Update()
    {
        refreshTimer -= Time.deltaTime;
        NormalizeTimer();
        UpdateUI(); //TODO: Might be removed for performance issues
        if (refreshTimer <= 0)
        {
            refreshTimer = refreshTimerMax;
            RefreshRecruitList();
        }
    }

    public void RefreshRecruitList()
    {
        recruitables = RecruitManager.Instance.GetRecruitableList();
        firstRecruitPanel.UpdatePanel(recruitables[0].stats,GetImageFromRarity(recruitables[0].rarity),recruitables[0].cost);
        secondRecruitPanel.UpdatePanel(recruitables[1].stats,GetImageFromRarity(recruitables[1].rarity),recruitables[0].cost);
        thirdRecruitPanel.UpdatePanel(recruitables[2].stats,GetImageFromRarity(recruitables[2].rarity),recruitables[0].cost);
        EnableAllButtons();
    }
    
    
    
    private Image GetImageFromRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                return commonRecruitImage;
            case Rarity.Rare:
                return rareRecruitImage;
            case Rarity.Epic:
                return epicRecruitImage;
            case Rarity.Legendary:
                return legendaryRecruitImage;
            default:
                throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null);
        }
    }
    
    private void NormalizeTimer()
    {
        float minutes = Mathf.FloorToInt(refreshTimer / 60);
        float seconds = Mathf.FloorToInt(refreshTimer % 60);
        timerText.text = timerPrefix + string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void RecruitConfirmation(int index)
    {
        recruitConfirmPanel.SetActive(true);
        selectedRecruitIndex = index;
    }
    
    
    public void CloseConfirmationPanel()
    {
        recruitConfirmPanel.SetActive(false);
        selectedRecruitIndex = -1;
    }
    
    public void Recruit()
    {
        if (PlayerDataManager.Instance.DoesPlayerHaveEnoughGold(recruitables[selectedRecruitIndex].cost))
        {
            PlayerDataManager.Instance.SpendGold(recruitables[selectedRecruitIndex].cost);
            var recruit = recruitables[selectedRecruitIndex];
            DisableButtonByIndex(selectedRecruitIndex);
            RecruitManager.Instance.RecruitCharacter(recruit);
            selectedRecruitIndex = -1;
            recruitConfirmPanel.SetActive(false);
        }
        else
        {
            recruitConfirmPanel.SetActive(false);
            Debug.Log("Not enough gold");
            //TODO: show not enough gold message orrrrrrrrr in the first hand don't allow player to click on the button
        }
        
    }

    private void DisableButtonByIndex(int index)
    {
        switch (index)
        {
            case 0:
                firstRecruitButton.interactable = false;
                break;
            case 1:
                secondRecruitButton.interactable = false;
                break;
            case 2:
                thirdRecruitButton.interactable = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(index), index, null);
        }
    }


    private void EnableAllButtons()
    {
        firstRecruitButton.interactable = true;
        secondRecruitButton.interactable = true;
        thirdRecruitButton.interactable = true;
    }

    private void UpdateUI()
    {
        var playerGold = PlayerDataManager.Instance.GetPlayerGold();
        //check recruit prices if player has enough gold if not disable button and make color of the gold text green
        firstRecruitPanel.UpdateGoldCostColor(playerGold>=recruitables[0].cost);
        secondRecruitPanel.UpdateGoldCostColor(playerGold>=recruitables[1].cost);
        thirdRecruitPanel.UpdateGoldCostColor(playerGold>=recruitables[2].cost);
        UpdateInteractibility(playerGold);
        
    }

    private void UpdateInteractibility(int playerGold)
    {
        if(playerGold >= recruitables[0].cost)
            firstRecruitButton.interactable = true;
        else
            firstRecruitButton.interactable = false;
        
        if(playerGold >= recruitables[1].cost)
            secondRecruitButton.interactable = true;
        else
            secondRecruitButton.interactable = false;
        
        if(playerGold >= recruitables[2].cost)
            thirdRecruitButton.interactable = true;
        else
            thirdRecruitButton.interactable = false;
    }
}
