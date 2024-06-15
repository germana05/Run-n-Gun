using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public int levens = 5;
    public float invincibleTimer = 0.1f;
    public float speed = 5f;
    public bool canTakeDamage = true;
    public bool playerInRange = false;
    public bool inWalkRange = false;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public GameObject statsObject;
    public GameObject shieldHoldLeft;
    public GameObject shieldHoldRight;
    public PlayerStats stats;

    void Start()
    {
        statsObject = GameObject.FindWithTag("Player");
        stats = statsObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (levens == 0)
        {
            Destroy(gameObject);
            stats.score += 100;
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

        if (levens == 5)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        else if (levens == 4)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if (levens == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (levens == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (levens == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }

        CheckPlayerPos();
        GoToPlayer();
    }

    private void CheckPlayerPos()
    {
        float playerPos = statsObject.transform.position.x;
        float enemyPos = transform.position.x;

        if (playerPos < enemyPos)
        {
            shieldHoldLeft.SetActive(true);
            shieldHoldRight.SetActive(false);
            Debug.Log("player is left of the enemy.");
        }
        else if (playerPos > enemyPos)
        {
            shieldHoldLeft.SetActive(false);
            shieldHoldRight.SetActive(true);
            Debug.Log("player is right of the enemy.");
        }
    }

    private void GoToPlayer()
    {
        float playerPos = statsObject.transform.position.x;
        float enemyPos = transform.position.x;
        Vector3 direction = Vector3.zero;

        if (playerPos < enemyPos && playerInRange == true && inWalkRange == true)
        {
            direction = Vector3.left;
        }
        else if (playerPos > enemyPos && playerInRange == true && inWalkRange == true)
        {
            direction = Vector3.right;
        }

        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kogel") && canTakeDamage == true)
        {
            levens--;
            Destroy(collision.gameObject);
            canTakeDamage = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
