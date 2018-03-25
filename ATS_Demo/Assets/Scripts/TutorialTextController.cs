using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour {

    public static TutorialTextController control;
    private Text tutorialText;
    private bool isShowing;
    
	// Use this for initialization
	void Awake () {
        control = this;
        tutorialText = gameObject.GetComponent<Text>();
	}

    public void SetTutorialText(string text) {
        tutorialText.text = text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(FadeOut());
        }
    }

    //If true show, if false hide text
    public void ShowText(bool show) {
        
        if (show)
        {
            Debug.Log("Entered: " + show);
            StartCoroutine(FadeIn());
        }
        else {
            Debug.Log("Entered: " + show);
            StartCoroutine(FadeOut()); 
        }

    }

    public bool GetShowText() {
        Debug.Log(tutorialText.color.a);
        if (tutorialText.color.a >= 0.9f)
        {
            return true;
        }
        else {
            return false;
        }
    }
        
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.1; f -= 0.1f)
        {
            Color color = new Color(1,1,1,f);
            tutorialText.color = color;
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            Color color = new Color(1, 1, 1, f);
            tutorialText.color = color;
            yield return null;
        }
    }

}
