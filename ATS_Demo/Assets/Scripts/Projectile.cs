using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject projectilePrefab;
    public GameObject projectilePrefabLeft;
    private List<GameObject> Projectiles = new List<GameObject>();
    private List<GameObject> ProjectilesLeft = new List<GameObject>();
    private PlayerController control;
    private float projectileVelocity;
    private float dartAmt;
    private bool playOnce = true;

    private void Awake()
    {
        control = gameObject.GetComponent<PlayerController>();
    }

    // Use this for initialization
    void Start () {
        projectileVelocity = 10;
        dartAmt = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["ShootLeftButton"])){

            if (control.GetLeft())
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefabLeft, new Vector3(transform.position.x - 1f, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
                ProjectilesLeft.Add(blowdart);
                dartAmt--;
            }

            else
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefab, new Vector3(transform.position.x + 1f, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
                Projectiles.Add(blowdart);
                dartAmt--;
            }
            
        }
        for (int i = 0; i < Projectiles.Count; i++){
            GameObject goBlowdart = Projectiles[i];
            if (goBlowdart != null){
                goBlowdart.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                //removing bullets that are off screen
                Vector3 dartScreenPos = Camera.main.WorldToScreenPoint(goBlowdart.transform.position);
                if (dartScreenPos.x >= Screen.width || dartScreenPos.x <= 0){
                    DestroyObject(goBlowdart);
                    Projectiles.Remove(goBlowdart);
                }

            }
        }
        for (int i = 0; i < ProjectilesLeft.Count; i++)
        {
            GameObject goBlowdartLeft = ProjectilesLeft[i];
            if (goBlowdartLeft != null)
            {
                goBlowdartLeft.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * projectileVelocity);
                //removing bullets that are off screen
                Vector3 dartScreenPos = Camera.main.WorldToScreenPoint(goBlowdartLeft.transform.position);
                if (dartScreenPos.x >= Screen.width || dartScreenPos.x <= 0)
                {
                    DestroyObject(goBlowdartLeft);
                    ProjectilesLeft.Remove(goBlowdartLeft);
                }

            }
        }
        if (Input.GetButtonDown("BlowdartRight") && dartAmt < 0)
        {
            TutorialTextController.control.SetTutorialText("You're out of darts!");
            if (playOnce)
            {
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }
	}
}
