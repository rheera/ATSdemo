using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffectController : MonoBehaviour {

    private Animator animator;
    public static SmokeEffectController control;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        control = this;
    }

    public void Play() {
        Debug.Log("IN HERE");
        animator.Play("SmokeEffect");
    }

}
