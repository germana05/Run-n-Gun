using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int levens;
    public int Damage;
    public int coins;
    public int keys;
    public GameObject deathScreen;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI keysText;

    void Start()
    {
        
    }

    void Update()
    {
        coinsText.text = coins.ToString();
        keysText.text = keys.ToString();
        if (levens == 0)
        {
            Destroy(gameObject);
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            deathScreen.SetActive(true);
        }
        if (levens > 3)
        {
            levens = 3;
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
        if (collision.gameObject.CompareTag("BadKogel"))
        {
            levens--;
        }
        if (collision.gameObject.CompareTag("Munt"))
        {
            coins++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Healing") && levens < 3)
        {
            levens++;
            Destroy(collision.gameObject);
        }
    }
}
