using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject storePanel;

    public Text magnetLevelText;
    public Text magnetButtonText;

    public Text immortalityLevelText;
    public Text immortalityButtonText;

    public Powerup magnet;
    public Powerup immortality;

    int coins;

    void UpdateUI()
    {
        magnetLevelText.text = magnet.ToString();
        magnetButtonText.text = magnet.UpgradeCostString();

        immortalityLevelText.text = immortality.ToString();
        immortalityButtonText.text = immortality.UpgradeCostString();
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayButton()
    {
        Debug.Log("Klik");
        SceneManager.LoadScene("Game");
    }

    public void SoundButton()
    {

    }




    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        UpdateUI();
    }

    void UpgradePowerup(Powerup powerup)
    {
        if(coins >= powerup.GetNextUpgradeCost()
            && powerup.IsMaxedOut() == false)
        {
            powerup.Upgrade();
            coins -= powerup.GetNextUpgradeCost();
            PlayerPrefs.SetInt("coins", coins);
            UpdateUI();
        }
    }
    public void MagnetUpgrade()
    {
        UpgradePowerup(magnet);
    }
    public void ImmortalityUpgrade()
    {
        UpgradePowerup(immortality);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
