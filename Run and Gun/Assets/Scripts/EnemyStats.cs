using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int levens = 3;
    public bool canTakeDamage = true;
    public bool canShoot = true;
    public float invincibleTimer = 1f;
    public float shootCooldown = 2f;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject kogel;
    public Transform kogelSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        if (canShoot == true)
        {
            Instantiate(kogel, kogelSpawn.position, kogelSpawn.rotation);
            canShoot = false;
        }

        if (canShoot == false)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (shootCooldown < 0)
        {
            canShoot = true;
            shootCooldown = 2f;
        }

        if (levens <= 0)
        {
            Destroy(gameObject);
        }

        if (canTakeDamage == false)
        {
            invincibleTimer -= Time.deltaTime;
        }

        if (invincibleTimer < 0f)
        {
            canTakeDamage = true;
            invincibleTimer = 1f;
        }

        if (levens == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (levens == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (levens == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kogel") && canTakeDamage == true)
        {
            levens--;
            canTakeDamage = false;
        }
    }
}
