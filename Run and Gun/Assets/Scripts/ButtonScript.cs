using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject optionScreenPause;
    public GameObject optionScreen;
    public GameObject pauseScreen;
    public GameObject endScreen;
    public GameObject helpScreen;
    public GameObject mainMenu;
    public AudioSource src;
    public AudioClip buttonPress;

    private void Awake()
    {
    }
    public void BackToMain()
    {
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Main Menu");
    }
    public void ToLevel2()
    {
        Time.timeScale = 1.0f;
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Level2");
    }
    public void ToLevel3()
    {
        Time.timeScale = 1.0f;
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Level3");
    }
    public void ToLevel4()
    {
        Time.timeScale = 1.0f;
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Level4");
    }
    public void ToLevel5()
    {
        Time.timeScale = 1.0f;
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Level5");
    }
    public void StartPlay()
    {
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Game");
    }
    public void OpenOptions()
    {
        src.clip = buttonPress;
        src.Play();
        optionScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        src.clip = buttonPress;
        src.Play();
        optionScreen.SetActive(false);
    }
    public void QuitGame()
    {
        src.clip = buttonPress;
        src.Play();
        Environment.Exit(0);
        Debug.Log("close Game");
    }
    public void Respawn()
    {
        Time.timeScale = 1.0f;
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Game");
    }
    public void QuitPlay()
    {
        src.clip = buttonPress;
        src.Play();
        SceneManager.LoadScene("Main Menu");
    }
    public void OpenHelp()
    {
        src.clip = buttonPress;
        src.Play();
        helpScreen.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseHelp()
    {
        src.clip = buttonPress;
        src.Play();
        helpScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
}
