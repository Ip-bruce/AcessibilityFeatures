using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AcessibilityTool : MonoBehaviour
{
    //AudioControll --------
    bool hasPlayedSound = false;

    public AudioClip WinSound;
    public AudioClip WallSound;

    public AudioClip LandingSignal;
    public AudioClip jumpSignal;
    public AudioSource Audio;
    public AudioClip Play;
    public AudioClip Config;
    public AudioClip Quit;
    public static bool isAcessible;
    public static bool isAudioCaption;
    public bool isClicked;
    public GameObject settingsPanel;

    //Objects and Texts
    //Texts
    int i;
    public GameObject[] Texts = new GameObject[5];
    public GameObject[] AcessibleImages = new GameObject[5];
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
       isAcessible = false;  
       isClicked = false;

       scene = SceneManager.GetActiveScene();
       Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(Input.GetKey(KeyCode.Escape))
      {
        isClicked = !isClicked;
        if(scene.name == "Game")
        {
           settingsPanel.SetActive(isClicked);
        }
      } 
        PlaySignal();
        Debug.Log("Sound Played: "+hasPlayedSound);
    //   if(isAudioCaption)
    //   {
    //     PlaySignal();
    //   }
    }

    public void AcessibilityChangeUI()
    {
        if(isAcessible)
        {
            for(i = 0; i <= Texts.Length; i++)
            {
                Texts[i].SetActive(false);
                AcessibleImages[i].SetActive(true);
            }
        }
        else
        {
            for(i = 0; i <= Texts.Length; i++)
            {
                Texts[i].SetActive(true);
                AcessibleImages[i].SetActive(false);
            }
        }
    }

    public void Toggle()
    {
        isAcessible = !isAcessible;
        if(isAcessible)
        {
            for(i = 0; i <= Texts.Length; i++)
            {
                Texts[i].SetActive(false);
                AcessibleImages[i].SetActive(true);
            }
        }
        else
        {
            for(i = 0; i <= Texts.Length; i++)
            {
                Texts[i].SetActive(true);
                AcessibleImages[i].SetActive(false);
            }
        }
    }

    public void SoundDescriptionToggle()
    {
        isAudioCaption = !isAudioCaption;
    }

    public void BlindSound(string sound)
    {
        if(isAudioCaption)
        {
            if(sound == "Play")
            {
                Audio.PlayOneShot(Play);
            }
            if(sound == "Config")
            {
                Audio.PlayOneShot(Config);
            }
            if(sound == "Quit")
            {
                Audio.PlayOneShot(Quit);
            }
        }
    }

    public void PlaySignal()
    {     
        if(isAudioCaption)
        {
            if(PlayerMovement.triggerTag == "None")
            {
                hasPlayedSound = false;
            }
            if(!hasPlayedSound)
            {

                if(PlayerMovement.triggerTag == "JumpSignal")
                {
                    Audio.PlayOneShot(jumpSignal,1.0f);
                    Debug.Log("JumpSOUND");
                    hasPlayedSound = true;
                }
                if(PlayerMovement.triggerTag == "LandingSignal")
                {
                    Audio.PlayOneShot(LandingSignal,1.0f);
                    Debug.Log("LandingSOUND");
                    hasPlayedSound = true;
                }
                if(PlayerMovement.triggerTag == "Wall")
                {
                    Audio.PlayOneShot(WallSound,1.0f);
                    Debug.Log("WallSOUND");
                    hasPlayedSound = true;
                }
                if(PlayerMovement.triggerTag == "Win")
                {
                    Audio.PlayOneShot(WinSound,1.0f);
                    Debug.Log("WINSOUND");
                    hasPlayedSound = true;
                }
            }
        }
        
    }

}
