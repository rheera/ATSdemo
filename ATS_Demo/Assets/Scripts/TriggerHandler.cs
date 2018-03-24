using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

    private CoinPickup coinPickup;
    private bool hiding = false;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public bool pickedup;

    // Use this for initialization
    void Start()
    {
        coinPickup = GameObject.FindGameObjectWithTag("CoinCollect").GetComponent<CoinPickup>();
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hiding) {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            rb2d.simulated = true;
            hiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            pickedup = true;
            Destroy(col.gameObject);
            GameControl.control.coins += 1;
        }
        if (col.CompareTag("Treasure"))
        {
            SceneControl.control.NextScene();
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
                spriteRenderer.enabled = !spriteRenderer.enabled;
                hiding = true;
            }
        }
    }

    public bool getHiding() {
        return hiding;
    }


}
