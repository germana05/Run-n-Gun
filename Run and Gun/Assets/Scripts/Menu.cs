using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject pauseScreen;
    public GameObject Settings;
    public bool isPaused;
    public float timePlaying;
    public int timePlayed;

    void Start()
    {
        
    }

    public void Update()
    {
        timePlaying += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timePlaying % 60);
        int minutes = Mathf.FloorToInt(timePlaying / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

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

    public void QuitGame()
    {
        Environment.Exit(0);
        Debug.Log("close Game");
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }

    public void SettingsOpen()
    {
        Settings.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void SettingsClose()
    {
        Settings.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void StartPlay()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitPlay()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
