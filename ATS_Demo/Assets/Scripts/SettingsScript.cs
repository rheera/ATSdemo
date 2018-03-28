using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{

    public Slider EffectVolume;
    public Slider MusicVolume;
    public Toggle Fullscreen;
    public Dropdown Quality;
    public Dropdown Resolution;
    public AudioMixer myMusic;
    public AudioMixer myEffect;
    Resolution[] resolutions;
    public int isFullScreen;
    int current_quality_index, prev_quality_index, current_resol_index, prev_resol_index;
    float current_mv, current_ev, prev_mv, prev_ev;

    void Start()
    {
        resolutions = Screen.resolutions;

        Resolution.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        current_resol_index = PlayerPrefs.GetInt("rs");
        prev_resol_index = current_resol_index;

        Resolution.AddOptions(options);
        Resolution.value = current_resol_index;
        Resolution.RefreshShownValue();

        EffectVolume.value = PlayerPrefs.GetFloat("ev");
        MusicVolume.value = PlayerPrefs.GetFloat("mv");
        current_quality_index = PlayerPrefs.GetInt("qi");
        Quality.value = current_quality_index;
        isFullScreen = PlayerPrefs.GetInt("fs");
        prev_ev = EffectVolume.value;
        prev_mv = MusicVolume.value;
        prev_quality_index = current_quality_index;
    }

    public void SetResolution(int resolIndex)
    {
        current_resol_index = resolIndex;
    }

    public void SetFullScreen(bool toggle)
    {
        isFullScreen = (toggle == true) ? 1 : 0;
    }

    public void SetQuality(int qualIndex)
    {
        current_quality_index = qualIndex;
    }

    public void SetVolume()
    {
        current_mv = MusicVolume.value;
        current_ev = EffectVolume.value;
    }

    public void Back()
    {
        MusicVolume.value = prev_mv;
        EffectVolume.value = prev_ev;
        Quality.value = prev_quality_index;
        Resolution.value = prev_resol_index;
        myMusic.SetFloat("musicMasterVolume", prev_mv);
        myEffect.SetFloat("soundEffectsMasterVolume", prev_ev);
        QualitySettings.SetQualityLevel(prev_quality_index);
        Resolution resolution = resolutions[prev_resol_index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Save()
    {
        prev_mv = MusicVolume.value;
        prev_ev = EffectVolume.value;
        myMusic.SetFloat("musicMasterVolume", current_mv);
        myEffect.SetFloat("soundEffectsMasterVolume", current_ev);
        prev_quality_index = current_quality_index;
        QualitySettings.SetQualityLevel(current_quality_index);
        prev_resol_index = current_resol_index;
        Resolution resolution = resolutions[current_resol_index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetFloat("mv", current_mv);
        PlayerPrefs.SetFloat("ev", current_ev);
        PlayerPrefs.SetInt("qi", current_quality_index);
        PlayerPrefs.SetInt("fs", isFullScreen);
        PlayerPrefs.SetInt("rs", current_resol_index);
        Screen.fullScreen = (isFullScreen == 1) ? true : false;
        PlayerPrefs.Save();
    }
}
