using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
        settingsPanel.SetActive(false);
    }


    public void update()
    {
      
    }

    public void SettingButton()
    {
        settingsPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        settingsPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

   
}
