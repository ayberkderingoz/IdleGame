using System.Collections;
using System.Collections.Generic;
using Recruit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RecruitPanel : MonoBehaviour
{ 
    //TODO: Rename text1, text2, text3, text4, text5
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;
    [SerializeField] private TextMeshProUGUI goldCostText;

    [SerializeField] private Image recruitImage;
    
    const string text1String = "Mining Level";
    const string text2String = "Woodcutting Level";
    const string text3String = "Farming Level";
    const string text5String = "Engineering Level";
    const string text4String = "Hunting Level";

    
    


    /*public void UpdateText(int miningLevel, int woodcuttingLevel, int farmingLevel, int engineeringLevel, int huntingLevel)
    {
        text1.text = text1String + " " + miningLevel;
        text2.text = text2String + " " + woodcuttingLevel;
        text3.text = text3String + " " + farmingLevel;
        text4.text = text4String + " " + huntingLevel;
        text5.text = text5String + " " + engineeringLevel;
    }*/

    public void UpdatePanel(Stats stats,Image image,int goldCost)
    {
        UpdateText(stats);
        UpdateImage(image);
        UpdateGoldCost(goldCost);
    }

    private void UpdateText(Stats stats)
    {
        text1.text = text1String + " " + stats.mineLevel;
        text2.text = text2String + " " + stats.woodLevel;
        text3.text = text3String + " " + stats.farmLevel;
        text4.text = text4String + " " + stats.damageLevel;
        text5.text = text5String + " " + stats.engineeringLevel;
    }
    private void UpdateImage(Image image)
    {
        recruitImage.sprite = image.sprite;
        recruitImage.color = image.color;
    }
    private void UpdateGoldCost(int goldCost)
    {
        goldCostText.text = goldCost.ToString();
    }
}
