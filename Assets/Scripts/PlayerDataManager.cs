using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    //singleton
    private static PlayerDataManager _instance;
    public static PlayerDataManager Instance => _instance;
    
    private PlayerData _playerData;

    private float autoSaveIntervalInSeconds = 300f;
    [SerializeField] private bool autoSaveEnabled = true;

    public Action<int> OnGoldChange;
    public Action<float,float> OnXpChanged;
    public Action<int> OnLevelChanged;
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        
    }


    private void Start()
    {
        LoadPlayerData();
        Debug.Log(_playerData.Xp);
        if (_playerData == null)
        {
            _playerData = new PlayerData();
            GainGold(200);
        }
        OnGoldChange?.Invoke(_playerData.Gold);
        OnXpChanged?.Invoke(_playerData.Xp,_playerData.XpToNextLevel);
        OnLevelChanged?.Invoke(_playerData.Level);
        
    }


    public PlayerData GetGameData()
    {
        return _playerData;
    }
    public void GainXp(int amount)
    {
        _playerData.Xp += amount;
        if (_playerData.Xp >= _playerData.XpToNextLevel)
        {
            _playerData.Xp -= _playerData.XpToNextLevel;
            _playerData.XpToNextLevel*=1.2f;
            GainLevel(1);
        }
        OnXpChanged?.Invoke(_playerData.Xp,_playerData.XpToNextLevel);
        
    }
    
    public bool DoesPlayerHaveEnoughGold(int amount)
    {
        return _playerData.Gold >= amount;
    }


    public int GetPlayerGold()
    {
        return _playerData.Gold;
    }
    public void GainGold(int amount)
    {
        _playerData.Gold += amount;
        OnGoldChange?.Invoke(_playerData.Gold);
    }
    public void SpendGold(int amount)
    {
        _playerData.Gold -= amount;
        OnGoldChange?.Invoke(_playerData.Gold);
    }
    public void GainLevel(int amount)
    {
        _playerData.Level += amount;
        OnLevelChanged?.Invoke(_playerData.Level);
    }
    
    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(_playerData);
    }
    public void LoadPlayerData()
    {
        _playerData = SaveSystem.LoadPlayerData();
    }
    
    
    private IEnumerator AutoSaveCoroutine()
    {
        while (autoSaveEnabled)
        {
            yield return new WaitForSeconds(autoSaveIntervalInSeconds);
            SavePlayerData();
        }
    }
    
}


public class PlayerData
{
    public int Level { get; set; }
    public int Gold { get; set; }
    public float Xp { get; set; }
    
    public float XpToNextLevel { get; set; }
    
    public PlayerData()
    {
        Level = 1;
        Gold = 0;
        Xp = 0;
        XpToNextLevel = 100;
    }

    
}
