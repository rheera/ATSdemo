﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public AudioClip jump;
    public AudioClip coin;
    public AudioClip blowDart;
    public AudioClip rock;
    public AudioClip hide;
    public AudioClip dead;
    //public AudioClip restart;
    public AudioClip stomp;
    public AudioClip treasure;
    public AudioClip rockThrow;

    public AudioSource audioSourceJump;
    public AudioSource audioSourceCoin;
    public AudioSource audioSourceBlowdart;
    public AudioSource audioSourceRock;
    public AudioSource audioSourceHide;
    public AudioSource audioSourceDead;
    //public AudioSource audioSourceRestart;
    public AudioSource audioSourceStomp;
    public AudioSource audioSourceTreasure;
    public AudioSource audioSourceRockThrow;

    public PhysicsObject player;
    public TriggerHandler trigger;
    public Projectile projectile;
    public GroundCollision rockClass;
    public PlayerController dying;
    public Rock actualRockClass;

    public static SoundEffectController control;

    private void Awake()
    {
        control = this;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["JumpButton"]) && (player.grounded || player.canDoubleJump) && !trigger.getCollidingHiding()) {
            audioSourceJump.PlayOneShot(jump);
        }
        if (trigger.pickedup == true) {
            audioSourceCoin.PlayOneShot(coin);
            trigger.pickedup = false;
        }
        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["ShootDart"]) && projectile.dartAmt > 0 && !trigger.getCollidingHiding())
        {
            audioSourceBlowdart.PlayOneShot(blowDart);
        }

        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["InteractButton"]) && trigger.getCollidingHiding())
        {
            audioSourceHide.PlayOneShot(hide);
        }

        /*if (rockClass.getRockNoise()){
            audioSourceRock.PlayOneShot(rock);
        }*/

        if (dying.getDead()){
            audioSourceDead.PlayOneShot(dead);
        }

        if (dying.getStomp())
        {
            audioSourceStomp.PlayOneShot(stomp);
        }

        if (trigger.getTreasure()){
            audioSourceTreasure.PlayOneShot(treasure);
        }

        if (Input.GetKeyDown(KeyBindScript.keybindControl.GetKeys()["ThrowRock"]) && actualRockClass.rockAmt > 0 && !trigger.getCollidingHiding()){
            audioSourceRockThrow.PlayOneShot(rockThrow);
        }
	}

    public void PlayHit() {
        audioSourceDead.PlayOneShot(stomp);
    }

    public void PlayRock()
    {
        audioSourceDead.PlayOneShot(rock);
    }

    public void PlayDeath() {
        audioSourceDead.PlayOneShot(dead);
    }
}
