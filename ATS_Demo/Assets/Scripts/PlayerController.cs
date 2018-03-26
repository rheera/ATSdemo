using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    private Vector3 originalPos;
    private bool dead = false;
    private bool jumping = false;
    public bool isLeft = true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private TriggerHandler trigger;
    

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trigger = GetComponent<TriggerHandler>();
    }
    
    // Use this for initialization
    void Start () {
        originalPos = gameObject.transform.position;
	}

    protected override void ComputeVelocity()
    {
        //Debug.Log(jumping);
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            maxSpeed = maxSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxSpeed = maxSpeed / 2;
        }

        //Will have to modify for double jump 
        if (Input.GetButtonDown("Jump")) 
        {
            if (grounded)
            {
                canDoubleJump = true;
                velocity.y = jumpTakeOffSpeed;
            }
            else {
                if (canDoubleJump) {
                    canDoubleJump = false;
                    velocity.y = 0;
                    velocity.y = jumpTakeOffSpeed * 0.75f;
                }
            }
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * .5f; //Reduce velocity when player lets go of jump button
            }
        }

        //Flips the sprite based on the direction it's going
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            isLeft = !isLeft;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //Animation Controller 
        if (!dead)
        {
            if (Input.GetButton("Jump"))
            {
                animator.SetInteger("state", 2);
            }

            if ((move.x > 0.2f || move.x < -0.2f) && grounded)
            {
                animator.SetInteger("state", 1);
            }
            else if (grounded)
            {
                animator.SetInteger("state", 0);
            }
            else if (velocity.y < -jumpTakeOffSpeed * 1.25) {
                animator.SetInteger("state", 3);
            }

        }
        else {
            animator.SetInteger("state", -1);
        }

        targetVelocity = move * maxSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag != "Hiding") { 
            if (collision.gameObject.tag == ("Crate")){
                float width = GetComponent<SpriteRenderer>().bounds.size.y;
                if ((this.gameObject.transform.position.y - width) + 1.1f >= collision.gameObject.transform.position.y)
                {
                    Destroy(collision.gameObject);
                    velocity.y = jumpTakeOffSpeed * 0.75f;
                }
                else {
                    dead = true;
                }
            }
            if (collision.gameObject.tag == ("Spike") || collision.gameObject.tag == ("Fire"))
            {
                dead = true;
            }
        }
    }

    public void setDead(bool dead) {
        this.dead = dead;
    }

    public bool GetLeft() {
        return isLeft;
    }

}
