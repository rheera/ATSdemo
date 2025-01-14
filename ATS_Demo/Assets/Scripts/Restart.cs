﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Restart : MonoBehaviour {

    private Scene scene;
    
	// Use this for initialization
    //Scene scene;
    void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            RestartScene();
        }
	}

    /*
    public IEnumerator RestartScene() {
        float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }*/
    public void RestartScene()
    {
        MusicController.control.Restart();
        SceneManager.LoadScene(scene.name);
    }

    public int sceneIndex() {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
