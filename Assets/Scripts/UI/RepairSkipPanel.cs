using System.Collections;
using System.Collections.Generic;
using Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairSkipPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI repairTimeText;
    [SerializeField] private Slider slider;
    
    private const string timerPrefix = "Repair Time: ";
    
    private float repairTime;
    private float currentRepairTime;
    
    
    
    
    public void InitializePanel(RepairableObject repairableObject)
    {
        Debug.Log("Initializing repair panel");
        repairTime = repairableObject.repairTime;
        currentRepairTime = repairableObject.repairTimer;
        slider.value = currentRepairTime / repairTime;
        NormalizeTimer(repairTime - currentRepairTime);
        
        if(repairableObject.workers.Count > 0)
        {
            StartCoroutine(UpdateTimer());
        }
    }

    
    private IEnumerator UpdateTimer()
    {
        while (currentRepairTime < repairTime)
        {
            yield return new WaitForSeconds(1f);
            currentRepairTime += 1f;
            slider.value = currentRepairTime / repairTime;
            NormalizeTimer(repairTime - currentRepairTime);
            yield return null;
        }
    }
    
    
    private void NormalizeTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        repairTimeText.text = timerPrefix + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    
    
    
    public void ClosePanel()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
    
    
    public void SkipRepair()
    {
        //TODO: This lines will be removed and replaced with the rewarded ad
        currentRepairTime = repairTime;
        slider.value = 1;
    }
}
