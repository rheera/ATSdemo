using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {

    public CircleCollider2D col;
    public BoxCollider2D coin;
    public BoxCollider2D hiding;
    public SoundEffectController sfxControl;
    private CircleCollider2D rock;

    private void Awake()
    {
        rock = gameObject.GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(rock, coin);
        Physics2D.IgnoreCollision(rock, hiding);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TileMap"))
        {
            //sfxControl.PlayRock();
            col.enabled = true;
            StartCoroutine(DestoryThing());
        }
    }

    IEnumerator DestoryThing() {

        yield return new WaitForSeconds(0.01f);
        DestroyObject(gameObject);
    }

}
