using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
    void ToLevel2()
    {
        SceneManager.LoadScene("");
    }
    void ToLevel5()
    {
        SceneManager.LoadScene("");
    }
    void ToLevel4()
    {
        SceneManager.LoadScene("");
    }
    void ToLevel3()
    {
        SceneManager.LoadScene("");
    }
    void StartPlay()
    {
        SceneManager.LoadScene("");
    }
    void OpenOptions()
    {

    }
    void QuitGame()
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
}
