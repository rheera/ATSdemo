using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectVoume : MonoBehaviour {

    float effectVolume = .2f;

    public AudioMixer audioMixer;

    void Start()
    {
        effectVolume = PlayerPrefs.GetFloat("effect volume");
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("soundEffectsMasterVolume", volume);
        PlayerPrefs.SetFloat("effect volume", volume);
        PlayerPrefs.Save();
        Debug.Log(volume);
    }
}
