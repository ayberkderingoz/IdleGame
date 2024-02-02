using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayerData(PlayerData playerData)
    {
        PlayerPrefs.SetInt("Level", playerData.Level);
        PlayerPrefs.SetInt("Gold", playerData.Gold);
        PlayerPrefs.SetFloat("Xp", playerData.Xp);
        PlayerPrefs.SetFloat("XpToNextLevel", playerData.XpToNextLevel);
    }

    public static PlayerData LoadPlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.Level = PlayerPrefs.GetInt("Level", 1);
        playerData.Gold = PlayerPrefs.GetInt("Gold", 200);
        playerData.Xp = PlayerPrefs.GetInt("Xp", 0);
        playerData.XpToNextLevel = PlayerPrefs.GetFloat("XpToNextLevel", 100);
        return playerData;
    }
}
