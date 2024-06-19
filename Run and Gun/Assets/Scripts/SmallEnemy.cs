using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    public int levens = 1;
    public float invincibleTimer = 0.1f;
    public float explosionTimer = 0.5f;
    public float speed = 5f;
    public bool canTakeDamage = true;
    public bool explode = false;
    public GameObject seeRange;
    public GameObject statsObject;
    public GameObject explosion;
    public GameObject canvas;
    public PlayerStats stats;
    public SeeRangeSmallEnemy seeRangeScript;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    void Start()
    {
        statsObject = GameObject.FindWithTag("Player");
        stats = statsObject.GetComponent<PlayerStats>();
        seeRangeScript = seeRange.GetComponent<SeeRangeSmallEnemy>();
        
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
        if (explode == true)
        {
            explosionTimer -= Time.deltaTime;
        }
        if (explosionTimer <= 0f)
        {
            Destroy(gameObject);
        }
        GoToPlayer();
    }

    private void GoToPlayer()
    {
        float playerPos = statsObject.transform.position.x;
        float enemyPos = transform.position.x;
        Vector3 direction = Vector3.zero;

        if (playerPos < enemyPos && seeRangeScript.playerInRange == true)
        {
            direction = Vector3.left;
            Debug.Log("move Left");
        }
        else if (playerPos > enemyPos && seeRangeScript.playerInRange == true)
        {
            direction = Vector3.right;
            Debug.Log("Move Right");
        }

        transform.position += direction * speed * Time.deltaTime;
    }

    private void Explode()
    {
        canvas.SetActive(false);
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        explosion.SetActive(true);
        explode = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kogel") && canTakeDamage == true)
        {
            levens--;
            Destroy(collision.gameObject);
            canTakeDamage = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}