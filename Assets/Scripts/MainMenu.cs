using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource soundSwitcher;
    public AudioClip title;
    public AudioClip start;

    public void PlayGame()
    {
        SceneManager.LoadScene("Prologue");
        soundSwitcher.PlayOneShot(start);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}