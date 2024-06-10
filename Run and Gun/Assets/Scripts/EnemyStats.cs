using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int levens = 3;
    public bool canTakeDamage = true;
    public bool canShoot = true;
    public float invincibleTimer = 0.1f;
    public float shootCooldown = 2f;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject kogel;
    public GameObject statsObject;
    public Transform kogelSpawn;
    public Transform player;
    public Transform rotateObject;
    public PlayerStats stats;

    void Start()
    {
        statsObject = GameObject.FindWithTag("Player");
        stats = statsObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (player != null && rotateObject != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotateObject.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

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
            stats.score += 10;
        }

        if (canTakeDamage == false)
        {
            invincibleTimer -= Time.deltaTime;
        }

        if (invincibleTimer < 0f)
        {
            canTakeDamage = true;
            invincibleTimer = 0.1f;
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
