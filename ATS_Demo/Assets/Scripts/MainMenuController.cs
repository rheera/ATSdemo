using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject button;

    private void Awake()
    {
        if (SceneControl.control.checkSave())
        {
            button.SetActive(true);
        }
    }

    public void PlayGame() {
        SceneControl.control.NextScene();
    }

        
    public void ExitGame() {
        Application.Quit();
    }

    public void Continue() {
        SceneControl.control.Load();
        GameControl.control.Load();
        SceneManager.LoadScene(SceneControl.control.GetSceneIndex());
    }
}
