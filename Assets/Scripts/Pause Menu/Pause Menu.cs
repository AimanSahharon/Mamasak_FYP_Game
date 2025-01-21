using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to load other scene

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool IsPaused = false; // Static flag to track pause state

    public void Pause()
    {
        IsPaused = true; // Set the flag to true when paused
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        IsPaused = false; // Set the flag to false when resuming
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        //IsPaused = false; // Reset the flag
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        StopAllCoroutines(); // Ensure no background coroutines are running

    // Reload the current scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        IsPaused = false; // Reset the flag
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
