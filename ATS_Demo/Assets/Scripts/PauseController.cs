using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject pauseMenu;
    private bool tutorialText = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused)
            {
                Resume();
            }
            else {
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

}
