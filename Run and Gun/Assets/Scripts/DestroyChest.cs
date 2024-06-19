using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChest : MonoBehaviour
{
    static public bool byChest = false;
    public PlayerStats stats;
    public GameObject statsObject;
    public GameObject coinSpawn;
    public GameObject coinToSpawn;
    public GameObject ammoSpawn;
    public GameObject ammoToSpawn;

    public SpriteRenderer sprite;
    public BoxCollider2D boxCollider2D;
    private void Start()
    {
        statsObject = GameObject.FindWithTag("Player");
        stats = statsObject.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (byChest == true && Input.GetKeyDown(KeyCode.E))
        {
            if (stats.hasKey == true)
            {
                sprite.enabled = false;
                boxCollider2D.enabled = false;
                stats.keys--;
                stats.score += 25;
                Instantiate(coinToSpawn, coinSpawn.transform.position, coinSpawn.transform.rotation);
                Instantiate(ammoToSpawn, ammoSpawn.transform.position, coinSpawn.transform.rotation);
                Debug.Log("key is used");
            }
            else
            {
                Debug.Log("has no key");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stats.currentChest = this.gameObject;
        if (collision.gameObject.CompareTag("Player"))
        {
            byChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            byChest = false;
            stats.currentChest = null;
        }
    }
}
