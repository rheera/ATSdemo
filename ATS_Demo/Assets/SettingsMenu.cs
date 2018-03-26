using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    // Use this for initialization

    public AudioMixer audioMixer;

	public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicMasterVolume", volume);
        Debug.Log(volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("soundEffectsMasterVolume", volume);
        Debug.Log(volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
