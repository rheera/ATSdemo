using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator animator;
    private PhysicsObject obj;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        obj = GetComponent<PhysicsObject>();
    }


    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetButton("Jump")) {
            while (!obj.grounded) {
                animator.Play("Jump");
            }
        }
    }
}
