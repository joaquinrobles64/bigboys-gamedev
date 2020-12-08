using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource soundSwitcher;
    public AudioClip title;
    public AudioClip start;

    void Awake() {
        // soundSwitcher.
    }

    public void PlayGame()
    {
        soundSwitcher.PlayOneShot(start);
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}