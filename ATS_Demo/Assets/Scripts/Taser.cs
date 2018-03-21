using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : MonoBehaviour
{

    public GameObject taserRightPrefab;
    public GameObject projectilePrefabLeft;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("TaserRight") || Input.GetButtonDown("TaserRight"))
        {
            GameObject taserRight = (GameObject)Instantiate(taserRightPrefab, transform.position, Quaternion.identity);
            Vector3 taserScreenPos = Camera.main.WorldToScreenPoint(taserRight.transform.position);
            DestroyObject(taserRight);
        }
    }
}
