using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schieten : MonoBehaviour
{
    public GameObject kogel;
    public Transform kogelSpawn;
    public float shootCooldown = 0.5f;
    public bool canShoot = true;

    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && canShoot == true)
        {
            Instantiate(kogel, kogelSpawn.position, kogelSpawn.rotation);
            canShoot = false;
        }

        if (canShoot == false)
        {
            shootCooldown = shootCooldown - Time.deltaTime;
        }

        if (shootCooldown <= 0)
        {
            canShoot = true;
            shootCooldown = 1f;
        }
    }
}
