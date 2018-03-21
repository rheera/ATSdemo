﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class move : PhysicsObject {
    public float lookRadius = 0f;

    Transform target;
    float destination;
    NavMeshAgent agent;
    int rest;
    public GameObject player;
    public bool isPatroller;
    public int patrolDistance;
    int patrolEnd;
    public int patrolDirection;  //1 is right   -1 is left
    bool returning = false;
    public GameObject visionCone;
    bool isFacingRight;
    bool isFacingLeft;
    public Collider2D vision;
    private SpriteRenderer spriteRenderer;
    private Animator animator;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        target = player.transform;
        rest = (int)transform.position.x;
        destination = rest;
        if (isPatroller)
        {
            animator.SetInteger("state", 1);
            patrolEnd = rest + (patrolDirection * patrolDistance);
            destination = patrolEnd;
        }
        isFacingLeft = true;

        if (isFacingLeft) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
	}
    void setFacingRight()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        visionCone.transform.Rotate(new Vector3(0, 180, 0));
        visionCone.transform.Translate(-5.13f, 0, 0);
        isFacingRight = true;
        isFacingLeft = false;
    }
    void setFacingLeft()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        visionCone.transform.Rotate(new Vector3(0, 180, 0));
        visionCone.transform.Translate(-5.13f, 0, 0);
        isFacingLeft = true;
        isFacingRight = false;
    }
	// Update is called once per frame
	void Update () {

        float distance = Vector2.Distance(target.position, transform.position);

        //if (distance <= lookRadius)
        //{
        //    destination = target.position.x;
        //}

        if (transform.position.x != destination)
        {
            if (transform.position.x > destination) {
                targetVelocity = Vector2.left;
                if (isFacingRight)
                {
                    Debug.Log("Here");
                    animator.SetInteger("state", 1);
                    setFacingLeft();
                }
            }
            else
            {
                targetVelocity = Vector2.right;
                if (isFacingLeft)
                {
                    Debug.Log("There");
                    animator.SetInteger("state", 1);
                    setFacingRight();
                }
            }
        }
        //print(destination);
        //print(transform.position.x);
        //print(rest);
        if ((int)transform.position.x == (int)destination) {
            
            if (isPatroller)
            {
                if (returning)
                {
                    destination = rest;
                    returning = false;
                }
                else
                {
                    destination = patrolEnd;
                    returning = true;
                }
            }
            else
            {
                destination = rest;
            }

        }
        if (distance > lookRadius)
        {

            if ((int)transform.position.x == rest && (int)destination == rest)
            {
                targetVelocity = Vector2.zero;
                animator.SetInteger("state", 0);
            }
        }

    }
    private void detect()
    {
  
     destination = target.position.x;
    
    }

    private void die()
    {
        Destroy(this.gameObject);
    }
}
