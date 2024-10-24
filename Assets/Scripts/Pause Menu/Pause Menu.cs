using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to load other scene

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

     public void Pause()
    {
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

     public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    

     public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
