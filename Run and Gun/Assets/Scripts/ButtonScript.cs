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
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void ToLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void ToLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void StartPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void OpenOptions()
    {
        optionScreen.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseOptions()
    {
        optionScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenOptionsPause()
    {
        optionScreenPause.SetActive(true);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
    }
    public void CloseOptionsToPause()
    {
        optionScreenPause.SetActive(false);
        pauseScreen.SetActive(true);
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
    public void QuitPlay()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OpenHelp()
    {
        helpScreen.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseHelp()
    {
        helpScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
}
