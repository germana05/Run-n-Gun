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
    public GameObject deathScreen;
    public TextMeshProUGUI coinsText;

    void Start()
    {
        
    }

    void Update()
    {
        coinsText.text = coins.ToString();
        if (levens == 0)
        {
            Destroy(gameObject);
            deathScreen.SetActive(true);
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
        }
    }
}
