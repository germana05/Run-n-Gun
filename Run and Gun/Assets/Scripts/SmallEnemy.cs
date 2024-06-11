using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    public int levens = 1;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kogel"))
        {
            levens--;
        }
    }
}
