using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

    public int coins;
    public Text coinsText;

    private void Start()
    {
        coins = GameControl.control.getCoins();
    }

    void Update()
    {
        coins = GameControl.control.getCoins();
        if (coins < 100)
        {
            coinsText.text = ("Coins: " + coins);
        }
        else {
            coinsText.text = ("Coins:" + coins);
        }
        
    }
}
