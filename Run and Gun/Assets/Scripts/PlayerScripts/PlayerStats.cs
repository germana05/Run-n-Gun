using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int levens;
    public int coins;
    public int keys;
    public int score;
    public int highScore;
    public bool hasKey = false;
    public bool canTakeDamage = true;
    public float invincibleTimer = 1f;
    public GameObject deathScreen;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject currentChest;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI keysText;


    void Start()
    {
        
    }

    void Update()
    {
        if (canTakeDamage == false)
        {
            invincibleTimer -= Time.deltaTime;
        }

        if (invincibleTimer <= 0 )
        {
            canTakeDamage = true;
            invincibleTimer = 1f;
        }

        coinsText.text = coins.ToString();
        keysText.text = keys.ToString();

        if (levens == 0)
        {
            Destroy(gameObject);
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        if (levens > 3)
        {
            levens = 3;
        }
        if (keys >= 1)
        {
            hasKey = true;
        }
        else
        {
            hasKey= false;
        }

        if (Input.GetKeyUp(KeyCode.E) && hasKey == true)
        {
            Debug.Log("opent kist");
            keys--;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BadKogel") && canTakeDamage == true)
        {
            levens--;
            canTakeDamage = false;
        }
        if (collision.gameObject.CompareTag("Munt"))
        {
            coins++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            keys++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Healing") && levens < 3)
        {
            levens++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && canTakeDamage == true)
        {
            levens--;
            canTakeDamage = false;
        }
    }
}
