using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    //black image
    public Texture2D fadeOutTexture;
    //speed of fade
    public float fadeSpeed = 0.8f;
    //order it appears, low number mean it renders on top 
    public int drawDepth = -1000;

    private float alpha = 1.0f;
    //direction, -1 means fade in, 1 means fade out
    private int fadeDir = -1;

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    //set fade directions
    public float BeginFade (int direction){
        fadeDir = direction;
        return (fadeSpeed); 
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
