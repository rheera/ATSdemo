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
    private bool gotTreasure = false;

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
        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["InteractButton"]) && hiding)
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
            Debug.Log("Hello There");
            gotTreasure = true;
            SceneControl.control.NextScene();
            Destroy(col.gameObject);
        }
        if (col.CompareTag("HidingSpot"))
        {
            collidingHiding = true;
            TutorialTextController.control.ShowText(true);
        }
        if (col.CompareTag("Door")) {
            SceneControl.control.NextScene();
        }
        if (col.CompareTag("Window"))
        {
            SceneControl.control.SetSceneIndex(SceneControl.control.GetSceneIndex() + 1);
            SceneControl.control.NextScene();
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("TutJump")) {
            TutorialTextController.control.SetTutorialText("Press \"Space\" to Jump");
            if (playOnce)
            {
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }

        if (col.CompareTag("TutGuard"))
        {
            
            if (playOnce)
            {
                TutorialTextController.control.SetTutorialText("This is a guard!\n Stay out of his vision\n You can also jump on his head to take him out");
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }
        if (col.CompareTag("TutProj")) {
            if (playOnce)
            {
                TutorialTextController.control.SetTutorialText("Darts incapacitate guards, fire with \"M\"\nRocks distract guards, throw with \"X\"");
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }
        if (col.CompareTag("TutKill"))
        {
            if (playOnce)
            {
                TutorialTextController.control.SetTutorialText("Be careful, if you kill too many guards\n reinforcements will arrive");
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }

        if (col.CompareTag("TutFinal"))
        {
            if (playOnce)
            {
                TutorialTextController.control.SetTutorialText("That's it, steal the treasure to advance and have fun!");
                TutorialTextController.control.ShowText(true);
                playOnce = false;
            }
        }

        if (col.CompareTag("HidingSpot"))
        {

            if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["InteractButton"]))
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

    public bool getCollidingHiding(){
        return collidingHiding;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HidingSpot") && gameObject.GetComponent<Rigidbody2D>().simulated)
        {
            collidingHiding = false;
            TutorialTextController.control.ShowText(false);
            playOnce = true;
        }

        if (col.CompareTag("TutJump") || col.CompareTag("TutJump")||col.CompareTag("TutProj")|| col.CompareTag("TutGuard")|| col.CompareTag("TutKill"))
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

    IEnumerator FadeTime()
    {
        yield return new WaitForSeconds(1);
        TutorialTextController.control.ShowText(false);
    }

    public bool getTreasure() {
        return gotTreasure;
    }

}
