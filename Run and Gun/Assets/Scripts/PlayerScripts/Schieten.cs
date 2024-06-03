using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schieten : MonoBehaviour
{
    public GameObject kogel;
    public Transform kogelSpawn;
    public float shootCooldown = 0.5f;
    public float kogelSpeed = 10f;
    public bool canShoot = true;

    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && canShoot == true)
        {
            ShootKogel();
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

    void ShootKogel()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (worldMousePosition - kogelSpawn.position).normalized;

        GameObject spawnedKogel = Instantiate(kogel, kogelSpawn.position, kogelSpawn.rotation);
        Rigidbody kogelRigidbody = spawnedKogel.GetComponent<Rigidbody>();

        if (kogelRigidbody != null)
        {
            kogelRigidbody.velocity = direction * kogelSpeed;
        }
    }
}
