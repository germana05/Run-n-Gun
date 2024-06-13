using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    public int levens = 1;
    public float invincibleTimer = 0.1f;
    public bool canTakeDamage = true;
    public GameObject statsObject;
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
            stats.score += 25;
            Destroy(gameObject);
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
}
