using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

    private CoinPickup coinPickup;
    private bool hiding = false;
    public bool pickedup;

    // Use this for initialization
    void Start()
    {
        coinPickup = GameObject.FindGameObjectWithTag("CoinCollect").GetComponent<CoinPickup>();
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
            
            if (Input.GetKey(KeyCode.E))
            {
                if (!hiding)
                {
                    Debug.Log("Hiding");
                    //Hiding Logic goes here
                    gameObject.tag = "Hiding";
                    hiding = true;
                }
                else if (hiding)
                {
                    Debug.Log("Out of Hiding");
                    //Reverting from hiding state here
                    gameObject.tag = "Player";
                    hiding = false;
                }
            }
        }
    }


}
