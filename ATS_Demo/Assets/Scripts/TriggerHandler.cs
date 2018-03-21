using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour {

    private CoinPickup coinPickup;
    private bool hiding = false;

    // Use this for initialization
    void Start()
    {
        coinPickup = GameObject.FindGameObjectWithTag("CoinCollect").GetComponent<CoinPickup>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
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
                Debug.Log("Button Press");
                if (!hiding)
                {
                    //Hiding Logic goes here
                    Debug.Log("In Hiding");
                    hiding = true;
                }
                else if (hiding)
                {
                    //Reverting from hiding state here
                    Debug.Log("Out of Hiding");
                    hiding = false;
                }
            }
        }
    }


}
