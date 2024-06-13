using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jump = 10f;
    public bool doubleJump;
    public bool isGrounded;
    public bool onSpikes;
    public Transform groundCheck;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    void Start()
    {
        // hier geef ik de rb de waarde van de Rigidbody2D aan.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = horizontalInput * walkSpeed;
        rb.velocity = velocity;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);

        // dit zorgt ervoor dat je kan jumpen.
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            doubleJump = true;
        }

        // dit zorgt er voor dat je kan dubbel jumpen.
        if (doubleJump == true && isGrounded == false && Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                doubleJump = false;
        }
        if (onSpikes == true && Input.GetKeyDown (KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            onSpikes = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            onSpikes = false;
        }
    }
}
