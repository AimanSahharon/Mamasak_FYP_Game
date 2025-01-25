using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To load other scenes

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    //[SerializeField] private AudioSource buttonSound; // Reference to the AudioSource component
    public static bool IsPaused = false; // Static flag to track pause state

    /*private void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    } */

    public void Pause()
    {
        //PlayButtonSound();
        IsPaused = true; // Set the flag to true when paused
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //PlayButtonSound();
        IsPaused = false; // Set the flag to false when resuming
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Settings()
    {
        //PlayButtonSound();
        IsPaused = true; // Set the flag to true when paused
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        //PlayButtonSound();
        IsPaused = false; // Reset the flag
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        //PlayButtonSound();
        IsPaused = false; // Reset the flag
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
