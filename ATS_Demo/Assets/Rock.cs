using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{

    public GameObject projectilePrefab;
    private float projectileVelocity;
    private PlayerController control;
    private List<GameObject> Projectiles = new List<GameObject>();
    private List<GameObject> ProjectilesLeft = new List<GameObject>();
    public float throwSpeed;
    public int rockAmt;
    public Text rockText;
    private bool playOnce = true;
    private TriggerHandler trigger;

    private void Awake()
    {
        control = gameObject.GetComponent<PlayerController>();
        trigger = gameObject.GetComponent<TriggerHandler>();

    }

    // Use this for initialization
    void Start()
    {
        projectileVelocity = 10;
        rockAmt = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rockText.text = ("Rock x " + rockAmt);
        if (Input.GetKeyDown(KeyCode.X) && rockAmt > 0 && !trigger.getHiding())
        {
            if (control.GetLeft())
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefab, new Vector3(transform.position.x - 1f, transform.position.y+ 0.1f, transform.position.z), Quaternion.identity);
                ProjectilesLeft.Add(blowdart);
                PhysicsObject obj = blowdart.GetComponent<PhysicsObject>();
                obj.SetVelocity(throwSpeed, 7f);
                rockAmt--;
            }
            else
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefab, new Vector3(transform.position.x + 1f, transform.position.y+0.1f, transform.position.z), Quaternion.identity);
                Projectiles.Add(blowdart);
                PhysicsObject obj = blowdart.GetComponent<PhysicsObject>();
                obj.SetVelocity(throwSpeed, 7f);
                rockAmt--;
            }
        }

        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBlowdart = Projectiles[i];
            if (goBlowdart != null)
            {
                goBlowdart.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
            }
        }

        for (int i = 0; i < ProjectilesLeft.Count; i++)
        {
            GameObject goBlowdartLeft = ProjectilesLeft[i];
            if (goBlowdartLeft != null)
            {
                goBlowdartLeft.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * projectileVelocity);
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && rockAmt <= 0)
        {
            playOnce = true;
            Debug.Log(rockAmt);
            TutorialTextController.control.SetTutorialText("You're out of rocks!");
            if (playOnce)
            {
                TutorialTextController.control.ShowText(true);
                playOnce = false;
                StartCoroutine(FadeTime());
            }
        }
    }

    IEnumerator FadeTime()
    {
        yield return new WaitForSeconds(1);
        TutorialTextController.control.ShowText(false);
    }


}
