using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    public AudioSource music;
    public AudioSource SFXSource;

    public AudioClip death;
    public AudioClip damage;
    public AudioClip chest;
    public AudioClip gem;
    public AudioClip coin;
    public AudioClip playerShoot;
    public AudioClip enemyShoot;
    public AudioClip Jump;
    public AudioClip buttonPressed;
    public AudioClip shootingTarget;
    public AudioClip smallEnemyExplode;
    public AudioClip bulletPickup;
    public AudioClip key;
    public AudioClip healing;
    public AudioClip hitShield;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Load()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void PlaySound(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
