using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    //slider component
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;

    void Start()
    {
        PlayerDataManager.Instance.OnXpChanged += OnXpChanged;
        PlayerDataManager.Instance.OnLevelChanged += OnLevelChanged;
    }
    
    
    public void OnXpChanged(float xp, float xpToNextLevel)
    {
        slider.value = xp / xpToNextLevel;
    }
    public void OnLevelChanged(int level)
    {
        levelText.text = level.ToString();
    }
}
