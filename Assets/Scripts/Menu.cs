using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioSource soundSwitcher;
    public AudioClip start;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        soundSwitcher.PlayOneShot(start);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}