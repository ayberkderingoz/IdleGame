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
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        LoadPlayerData();
        if (_playerData == null)
        {
            _playerData = new PlayerData();
        }
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
        
    }

    public void GainGold(int amount)
    {
        _playerData.Gold += amount;
    }
    public void SpendGold(int amount)
    {
        _playerData.Gold -= amount;
    }
    public void GainLevel(int amount)
    {
        _playerData.Level += amount;
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