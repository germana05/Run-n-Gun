using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Toggle vSyncToggle;
    public Toggle fullscreenToggle;
    public AudioSource src;
    public AudioClip toggleSound;

    public void Options()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        vSyncToggle.isOn = QualitySettings.vSyncCount != 0;
    }

    public void ApplyOptions()
    {
        Debug.Log("Fullscreen toggle is " + fullscreenToggle.isOn);
        Debug.Log("VSync toggle is " + vSyncToggle.isOn);

        src.clip = toggleSound;
        src.Play();

        Screen.fullScreen = fullscreenToggle.isOn;

        if (vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
