using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseController : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject pauseMenu;
    private bool tutorialText = false;
    public AudioMixer musicMasterMixer;
    public AudioMixer sfxMasterMixer;
    private float normalMusicVolume, normalSFXVolume;

    private void Awake()
    {
        normalMusicVolume = GetMasterLevel(musicMasterMixer);
        normalSFXVolume = GetMasterLevel(sfxMasterMixer);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused)
            {
                musicMasterMixer.SetFloat("musicMasterVolume", normalMusicVolume);
                sfxMasterMixer.SetFloat("soundEffectsMasterVolume", normalSFXVolume);

                Resume();
            }
            else {
                sfxMasterMixer.SetFloat("soundEffectsMasterVolume", -20f);
                musicMasterMixer.SetFloat("musicMasterVolume", -20f);
                Pause();
            }
        }
	}

    public void Resume()
    {
        if (tutorialText) {
            TutorialTextController.control.ShowText(true);
            tutorialText = false;
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        if (TutorialTextController.control.GetShowText())
        {
            tutorialText = true;
            TutorialTextController.control.ShowText(false);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Save() {
        SceneControl.control.Save();
        GameControl.control.Save();
    }

    public void Load() {
        SceneControl.control.Load();
        GameControl.control.Load();
    }

    public void Quit() 
    {
        Application.Quit();
    }

    float GetMasterLevel(AudioMixer masterMixer)
    {
        float value;
        bool result = masterMixer.GetFloat("masterVolume", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }

}
