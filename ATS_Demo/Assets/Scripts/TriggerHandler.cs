using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

    private CoinPickup coinPickup;
    private bool hiding = false;
    private Rigidbody2D rb2d;
    public bool pickedup;

    // Use this for initialization
    void Start()
    {
        coinPickup = GameObject.FindGameObjectWithTag("CoinCollect").GetComponent<CoinPickup>();
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hiding) {
          //  rb2d.simulated = true;
            hiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            pickedup = true;
            Destroy(col.gameObject);
            coinPickup.coins += 1;
        }
        if (col.CompareTag("Treasure"))
        {
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("HidingSpot"))
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<Rigidbody2D>().simulated = !gameObject.GetComponent<Rigidbody2D>().simulated;
                hiding = true;
                //gameObject.GetComponent<CapsuleCollider2D>().enabled = !gameObject.GetComponent<CapsuleCollider2D>().enabled;
            }
        }
    }

    public bool getHiding() {
        return hiding;
    }


}
