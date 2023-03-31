using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public AudioMixer mainMixer;

    void Start()
    {
        settingsMenu.SetActive(false);
    }

    public void SetVolume(float Volume)
    {
        mainMixer.SetFloat("Volume", Volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void GoBack()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
