using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public GameObject projectilePrefab;
    private float projectileVelocity;
    private bool playOnce = true;
    private PlayerController control;
    private List<GameObject> Projectiles = new List<GameObject>();
    private List<GameObject> ProjectilesLeft = new List<GameObject>();
    public float throwSpeed;

    private void Awake()
    {
        control = gameObject.GetComponent<PlayerController>();
    }

    // Use this for initialization
    void Start()
    {
        projectileVelocity = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (control.GetLeft())
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefab, new Vector3(transform.position.x - 1f, transform.position.y+ 0.1f, transform.position.z), Quaternion.identity);
                ProjectilesLeft.Add(blowdart);
                PhysicsObject obj = blowdart.GetComponent<PhysicsObject>();
                obj.SetVelocity(throwSpeed, 7f);
            }
            else
            {
                GameObject blowdart = (GameObject)Instantiate(projectilePrefab, new Vector3(transform.position.x + 1f, transform.position.y+0.1f, transform.position.z), Quaternion.identity);
                Projectiles.Add(blowdart);
                PhysicsObject obj = blowdart.GetComponent<PhysicsObject>();
                obj.SetVelocity(throwSpeed, 7f);
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
    }


}
