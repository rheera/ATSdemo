using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automove : PhysicsObject
{

    public Collider2D collider;
    protected float direction = 1;
    protected int speed = 2;
    private BoxCollider2D hitbox;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        hitbox = GameObject.FindGameObjectWithTag("Crate").GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        if (direction == 1)
        {
            targetVelocity = Vector2.left * speed;
        }
        else {
            targetVelocity = Vector2.right * speed;
        }

        if (targetVelocity.x != 0.0f)
        {
            animator.SetInteger("state", 1);
        }
        else {
            animator.SetInteger("state", 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            direction = direction * -1;
        }
        // if hit by a dart, stop the crate from moving and turn off the crate's collider box
        if (coll.gameObject.tag == "Dart"){
            speed = 0;
            hitbox.enabled = false;
        }
    }
}


