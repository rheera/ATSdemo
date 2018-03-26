using System.Collections;
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
    bool isFacingRight = true;
    bool isFacingLeft = false;
    public Collider2D vision;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool inPursuit;
    public int pursuitSpeed;
    public bool startLeft;
    private bool startLeft2;



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
        
        if (startLeft)
        {
            Debug.Log(startLeft);
            isFacingLeft= true;
            isFacingRight = false;
            startLeft2 = startLeft;
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
        if (startLeft) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            visionCone.transform.Rotate(new Vector3(0, 180, 0));
            visionCone.transform.Translate(-5.13f, 0, 0);
            startLeft = false;
        }
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
                if (inPursuit)
                {
                    targetVelocity = Vector2.left * pursuitSpeed;
                }
                else
                {
                    targetVelocity = Vector2.left;
                }
                if (isFacingRight)
                {
                    animator.SetInteger("state", 1);
                    setFacingLeft();
                }
            }
            else
            {
                if (inPursuit)
                {
                    targetVelocity = Vector2.right * pursuitSpeed;
                }
                else
                {
                    targetVelocity = Vector2.right;
                }
                if (isFacingLeft)
                {
                    animator.SetInteger("state", 1);
                    setFacingRight();
                }
            }
        }

        if ((int)transform.position.x == (int)destination) {
            inPursuit = false;
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
                if (startLeft2 && !isFacingLeft) {
                    setFacingLeft();
                }
            }
        }

    }
    private void detect()
    {
        inPursuit = true;
     destination = target.position.x;
     animator.SetInteger("state", 1);
    }

    private void detectNoise(float noise) {
        Debug.Log(noise);
        inPursuit = true;
        destination = noise;
        animator.SetInteger("state", 1);
    }

    private void die()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // if hit by a dart, stop the crate from moving and turn off the crate's collider box
        if (coll.gameObject.tag == "Dart")
        {
            die();
            Destroy(coll.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Noise")) {
            detectNoise(collision.gameObject.transform.position.x);
            DestroyObject(collision.gameObject);
        }
    }

}
