using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public AudioClip jump;
    private AudioSource audioSource;
    public PhysicsObject player;

	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && (player.grounded || player.canDoubleJump)) {
            audioSource.PlayOneShot(jump);
        }
	}
}
