using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public void PlayGame() {
        SceneControl.control.NextScene();
    }

        
    public void ExitGame() {
        Application.Quit();
    }
}
