using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public static SceneControl control;
    public int sceneIndex; //Current scene
    
    // Use this for initialization
	void Awake() {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

     // Update is called once per frame
    void SetSceneIndex (int index) {
        sceneIndex = index;
	}

    public int GetSceneIndex() {
        return sceneIndex;
    }

    public void NextScene() {
        sceneIndex += 1;
        SceneManager.LoadScene(sceneIndex);
        Debug.Log(sceneIndex);
    }

    //Checks to see if a save file exists
    public bool checkSave() {
        return File.Exists(Application.persistentDataPath + "/sceneInfo.dat");
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/sceneInfo.dat");
        SceneData sceneData = new SceneData(sceneIndex);
        bf.Serialize(file, sceneData);
        Debug.Log("Saving Scene : " + sceneIndex);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/sceneInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/sceneInfo.dat", FileMode.Open);
            SceneData data = (SceneData)bf.Deserialize(file);
            file.Close();
            sceneIndex = data.getSceneIndex();
            SceneManager.LoadScene(sceneIndex);
        }
    }

}


[Serializable]
class SceneData
{
    private int sceneIndex;

    public SceneData(int index)
    {
        sceneIndex = index;
    }

    public int getSceneIndex()
    {
        return sceneIndex;
    }

}


