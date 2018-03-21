using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public AudioClip jump;
    public AudioClip coin;
    private AudioSource audioSourceJump;
    private AudioSource audioSourceCoin;
    public PhysicsObject player;
    public TriggerHandler trigger;

	// Use this for initialization
	void Awake () {
        audioSourceJump = GetComponent<AudioSource>();
        audioSourceCoin = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetButtonDown("Jump") && (player.grounded || player.canDoubleJump)) {
            audioSourceJump.PlayOneShot(jump);
        }
        if (trigger.pickedup == true) {
            audioSourceCoin.PlayOneShot(coin);
            trigger.pickedup = false;
        }

	}
}
