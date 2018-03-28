using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public static MusicController control;
    public AudioMixerSnapshot stealth, inPursuit;
    public float bpm = 128; //Represents Beats Per Minute

    private float m_TransitionIn, m_TransitionOut, m_QuarterNote;

    // Use this for initialization
    void Start () {
        control = this;
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote; // 1 bar transition in (quick fade in)
        m_TransitionOut = m_QuarterNote * 4; //8 bar transition out (slow fade out)
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DetectionZone")) {
            inPursuit.TransitionTo(m_TransitionIn);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("DetectionZone"))
        {
            stealth.TransitionTo(m_TransitionOut);
        }

    }

    public void Restart() {
        stealth.TransitionTo(m_TransitionOut);
    }

    IEnumerator Fadeout() {
        yield return new WaitForSeconds(5); //Still in pursuit mode, want to delay the tranistion until player has successfully avoided capture
        stealth.TransitionTo(m_TransitionOut);
    }
}
