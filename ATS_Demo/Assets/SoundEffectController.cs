using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public AudioClip jump;
    public AudioClip coin;

    public AudioClip blowDart;
    public AudioSource audioSourceJump;
    public AudioSource audioSourceCoin;
    public AudioSource audioSourceBlowdart;

    public PhysicsObject player;
    public TriggerHandler trigger;
    public Projectile projectile;

	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetButtonDown("Jump") && (player.grounded || player.canDoubleJump)) {
            audioSourceJump.PlayOneShot(jump);
        }
        if (trigger.pickedup == true) {
            audioSourceCoin.PlayOneShot(coin);
            trigger.pickedup = false;
        }
        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["ShootLeftButton"]) && projectile.dartAmt > 0)
        {
            audioSourceBlowdart.PlayOneShot(blowDart);
        }
	}

    public void PlayHit() {
        Debug.Log("Hit Detected");
        audioSourceCoin.PlayOneShot(coin);
    }

    public void PlayRock() {
        Debug.Log("Hit Detected");
        audioSourceCoin.PlayOneShot(coin);
    }
}
