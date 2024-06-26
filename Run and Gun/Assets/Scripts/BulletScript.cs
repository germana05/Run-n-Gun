using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public GameObject statsObject;
    public PlayerStats stats;
    public float force;
    public float timer;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        statsObject = GameObject.FindWithTag("Player");
        stats = statsObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("ShootingDisc"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            stats.score += 20;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
