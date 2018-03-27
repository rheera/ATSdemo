using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public float fadeInTime;
    private CoinPickup coinPickup;
    private bool hiding = false;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public bool pickedup;
    private bool fading = false;
    private bool playOnce = true;
    private bool collidingHiding = false;

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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && hiding)
        {
            Debug.Log("Entered");
            SmokeEffectController.control.Play();
            spriteRenderer.enabled = !spriteRenderer.enabled;
            rb2d.simulated = true;
            hiding = false;
        }
        if (collidingHiding)
        {
            if (hiding)
            {
                TutorialTextController.control.SetTutorialText("Press \"E\" to exit the hiding spot\n You can not be detected while hiding");
                if (playOnce)
                {
                    TutorialTextController.control.ShowText(true);
                    playOnce = false;
                }
            }
            else
            {
                TutorialTextController.control.SetTutorialText("This is a hiding spot\n Press \"E\" to enter");
                playOnce = true;
            }
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
        if (col.CompareTag("HidingSpot"))
        {
            collidingHiding = true;
            TutorialTextController.control.ShowText(true);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("TutJump")) {
            Debug.Log("Eneterd Tutorial Zone");
            TutorialTextController.control.SetTutorialText("Press \"Space\" to Jump");
            if (playOnce)
            {
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }

        if (col.CompareTag("HidingSpot"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                SmokeEffectController.control.Play();
                gameObject.GetComponent<Rigidbody2D>().simulated = !gameObject.GetComponent<Rigidbody2D>().simulated;
                spriteRenderer.enabled = !spriteRenderer.enabled;
                StartCoroutine(Hiding());
                //StartCoroutine(FadeIn());
            }
        }
    }

    public bool getHiding()
    {
        return hiding;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HidingSpot") && gameObject.GetComponent<Rigidbody2D>().simulated)
        {
            collidingHiding = false;
            TutorialTextController.control.ShowText(false);
            playOnce = true;
        }

        if (col.CompareTag("TutJump"))
        {
            TutorialTextController.control.ShowText(false);
            playOnce = true;
        }

    }
    IEnumerator Hiding()
    {
        Debug.Log("Here");
        yield return new WaitForSeconds(0.2f);
        hiding = true;
    }

    IEnumerator FadeIn()
    {
        fading = true;
        yield return new WaitForSeconds(fadeInTime);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        fading = false;
    }

}
