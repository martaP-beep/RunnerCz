using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject storePanel;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
