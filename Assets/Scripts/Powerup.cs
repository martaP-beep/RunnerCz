using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : ScriptableObject
{
    public bool isActive;

    [SerializeField]
    protected PowerupStats duration;

    [SerializeField]
    protected int currentLevel = 1;

    [SerializeField]
    protected int maxLevel = 3;

    [SerializeField]
    protected int[] UpgradeCost;

    public float GetDuration()
    {
        return duration.GetValue(currentLevel);
    }

    public bool IsMaxedOut()
    {
        return currentLevel == maxLevel;
    }

    public int GetNextUpgradeCost()
    {
        if(IsMaxedOut() == false)
        {
            return UpgradeCost[currentLevel-1];
        }
        else
        {
            return -1;
        }
    }
    public void Upgrade()
    {
        if (IsMaxedOut() == false)
        {
            currentLevel++;
            SavePowerupLevel();
        }
    }
    private void Awake()
    {
        LoadPowerupLevel();
    }

    void SavePowerupLevel()
    {
        string key = name + "Level"; 
        PlayerPrefs.SetInt(key, currentLevel);
    }

    void LoadPowerupLevel()
    {
        string key = name + "Level";
        if (PlayerPrefs.HasKey(key))
        {
            currentLevel = PlayerPrefs.GetInt(key);
        }
    }

    public override string ToString()
    {
        string text = $"{name}\n Lvl.{currentLevel}";
        if (IsMaxedOut())
        {
            text += " MAX";
        }
        return text;

    }
    public string UpgradeCostString()
    {
        if (IsMaxedOut())
        {
            return "MAXED OUT";
        }
        else
        {
            return $"UPGRADE \nCOST: {GetNextUpgradeCost()}";
        }
    }

}
