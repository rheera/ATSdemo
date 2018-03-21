using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

    public int coins;
    public Text coinsText;

    void Update()
    {
        coinsText.text = ("Coins: " + coins);
    }
}
