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
    //public int highScore;
    public bool hasKey = false;
    public bool canTakeDamage = true;
    public float invincibleTimer = 1f;
    public GameObject deathScreen;
    public GameObject endScreen;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject coins1;
    public GameObject coins2;
    public GameObject coins3;
    public GameObject currentChest;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    //public TextMeshProUGUI highScoreText;


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

        keysText.text = keys.ToString();
        scoreText.text = score.ToString();
        endScoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();

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

        if (coins == 3)
        {
            coins1.SetActive(true);
            coins2.SetActive(true);
            coins3.SetActive(true);
        }
        else if (coins == 2)
        {
            coins1.SetActive(true);
            coins2.SetActive(true);
            coins3.SetActive(false);
        }
        else if (coins == 1)
        {
            coins1.SetActive(true);
            coins2.SetActive(false);
            coins3.SetActive(false);
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
        if (collision.gameObject.CompareTag("Spikes") && canTakeDamage == true)
        {
            levens--;
            canTakeDamage = false;
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            score = score + 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ending"))
        {
            Time.timeScale = 0f;
            endScreen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
