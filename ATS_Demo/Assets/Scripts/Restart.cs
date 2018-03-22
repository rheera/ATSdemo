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

    /*
    public IEnumerator RestartScene() {
        float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }*/
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
