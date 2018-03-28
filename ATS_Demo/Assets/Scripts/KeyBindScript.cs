using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour {

    public static KeyBindScript keybindControl;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text jump, left, right, interact, shootLeft, shootRight;

    private GameObject currentKey;

    private Color32 normal = new Color(39, 171, 249, 255);
    private Color32 slected = new Color32(239, 116, 36, 255);

    private void Awake()
    {
        keybindControl = this;
    }

    // Use this for initialization
    void Start () {
        keys.Add("JumpButton", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("JumpButton", "W")));
        keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton", "A")));
        keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton", "D")));
        keys.Add("InteractButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("InteractButton", "E")));
        keys.Add("ShootDart", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ShootDart", "N")));
        keys.Add("ThrowRock", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ThrowRock", "M")));

        jump.text = keys["JumpButton"].ToString();
        left.text = keys["LeftButton"].ToString();
        right.text = keys["RightButton"].ToString();
        interact.text = keys["InteractButton"].ToString();
        shootLeft.text = keys["ShootDart"].ToString();
        shootRight.text = keys["ThrowRock"].ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keys["JumpButton"]))
        {
            Debug.Log("Jump");
        }
        if (Input.GetKeyDown(keys["LeftButton"]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["RightButton"]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["InteractButton"]))
        {
            Debug.Log("Interact");
        }
        if (Input.GetKeyDown(keys["ShootDart"]))
        {
            Debug.Log("Shoot Dart");
        }
        if (Input.GetKeyDown(keys["ThrowRock"]))
        {
            Debug.Log("Throw Rock");
        }
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = slected;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            Debug.Log(key.Key);
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
            Debug.Log("Scanning");
        }

        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    public Dictionary<string, KeyCode> GetKeys() {
        return keys;
    }

}
