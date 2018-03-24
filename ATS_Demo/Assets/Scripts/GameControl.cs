using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameControl : MonoBehaviour {

    public static GameControl control;
    public int coins;

	// Use this for initialization
	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this) {
            Destroy(gameObject);
        }
        
	}

    public void Save() {
        //Debug.Log("Entered Save: " + coins );
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData(coins);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            coins = data.getCoins();
           // Debug.Log("Entered Secondary Load: " + coins);
        }
    }

    public int getCoins() {
        return coins;
    }

}

//Serializable data container
[Serializable]
class PlayerData {
    private int coins;

    public PlayerData(int coins) {
        this.coins = coins;
    }

    public int getCoins() {
        return coins;
    }

}

