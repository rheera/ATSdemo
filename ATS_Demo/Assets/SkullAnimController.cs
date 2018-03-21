using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAnimController : MonoBehaviour {

    private Animator animator;
    public int animState = 0;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (animState != 0) {
            animator.SetInteger("state", animState);
        }
	}
}
