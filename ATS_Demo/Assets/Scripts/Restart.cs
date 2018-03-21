using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
    //Scene scene;
    void Start () {
        //Scene scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            RestartScene();
        }
	}

    public void RestartScene() {
        SceneManager.LoadScene(0);
    }
}
