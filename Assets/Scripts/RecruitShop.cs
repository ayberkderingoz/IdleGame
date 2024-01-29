using System;
using System.Collections;
using System.Collections.Generic;
using Recruit;
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
    
    
    
    //recruit timer
    private float refreshTimer;
    [SerializeField] private float refreshTimerMax = 300f;

    private List<Recruitable> recruitables;

    
    
    //every 5 min refresh recruit list
    private void Start()
    {
        RefreshRecruitList();
        refreshTimer = refreshTimerMax;
    }
    
    private void Update()
    {
        refreshTimer -= Time.deltaTime;
        if (refreshTimer <= 0)
        {
            refreshTimer = refreshTimerMax;
            RefreshRecruitList();
        }
    }

    private void RefreshRecruitList()
    {
        recruitables = RecruitManager.Instance.GetRecruitableList();
        firstRecruitPanel.UpdatePanel(recruitables[0].stats,GetImageFromRarity(recruitables[0].rarity),recruitables[0].cost);
        secondRecruitPanel.UpdatePanel(recruitables[1].stats,GetImageFromRarity(recruitables[1].rarity),recruitables[0].cost);
        thirdRecruitPanel.UpdatePanel(recruitables[2].stats,GetImageFromRarity(recruitables[2].rarity),recruitables[0].cost);
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
    

}
