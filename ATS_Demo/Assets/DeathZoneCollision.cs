using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneCollision : MonoBehaviour {

    private PlayerController controller;
    private Restart restart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            controller = collision.gameObject.GetComponent<PlayerController>();
            restart = collision.gameObject.GetComponent<Restart>();
            controller.setDead(true);
            restart.RestartScene();
            //Restart function
        }
    }

}
/*
 * private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           // Destroy(collision.collider.gameObject);
        }
    }
 * 
 **/
