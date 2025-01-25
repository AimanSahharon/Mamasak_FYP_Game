using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to load other scene

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    public static bool IsPaused = false; // Static flag to track pause state

    public void Pause()
    {
        IsPaused = true; // Set the flag to true when paused
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        IsPaused = false; // Set the flag to false when resuming
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Settings()
    {
        IsPaused = true; // Set the flag to true when paused
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        IsPaused = false; // Reset the flag
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //StopAllCoroutines(); // Ensure no background coroutines are running

    // Reload the current scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        IsPaused = false; // Reset the flag
        SceneManager.LoadSceneAsync("Main Menu"); 
    }
}
