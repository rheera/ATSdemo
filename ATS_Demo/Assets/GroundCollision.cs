using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {

    public CircleCollider2D col;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TileMap"))
        {
            col.enabled = true;
            StartCoroutine(DestoryThing());
        }
    }

    IEnumerator DestoryThing() {

        yield return new WaitForSeconds(0.01f);
        DestroyObject(gameObject);
    }

}
