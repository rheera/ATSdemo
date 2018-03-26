using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;

    public bool grounded;
    public bool canDoubleJump = true;
    protected Vector2 groundNormal;

    protected Vector2 targetVelocity; //Stores incoming value from user input
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f; // Padding on collider check so colliders don't accidentally get stuck

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
	
	// Update is called once per frame
	void Update () {
        targetVelocity = Vector2.zero;
        ComputeVelocity();    
	}

    protected virtual void ComputeVelocity() {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime; //Calculate velocity on y axis every frame to simulate gravity
        velocity.x = targetVelocity.x;
        grounded = false;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 deltaPosition = velocity * Time.deltaTime; //Get the new position of the object each frame

        Vector2 move = moveAlongGround * deltaPosition.x; //X movement
        Movement(move, false);

        //Y movement
        move = Vector2.up * deltaPosition.y; //Calculate the movement of the object
        Movement(move, true); //Move object
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            //Determine number of other colliders we would overlap with
            int count = rb2d.Cast(move, contactFilter, hitBuffer,distance + shellRadius);
            hitBufferList.Clear();
            for (int i =0; i <count; i++) {
                hitBufferList.Add(hitBuffer[i]);
            }

            //Determine angle at which we are hitting the collider
            for (int i = 0; i < hitBufferList.Count; i++) {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY) {
                    grounded = true;
                    if (yMovement) {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0) {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
    public void SetVelocity(float vely, float velx) {
        velocity.y = vely;
        targetVelocity.x = velx;
        Debug.Log("Here");
        Debug.Log(this);
    }

}
