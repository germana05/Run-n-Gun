using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timePlayedText;
    public GameObject pauseScreen;
    public GameObject Settings;
    public bool isPaused;
    public float timePlaying;

    void Start()
    {
        
    }

    public void Update()
    {
        timePlaying += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timePlaying % 60);
        int minutes = Mathf.FloorToInt(timePlaying / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timePlayedText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
