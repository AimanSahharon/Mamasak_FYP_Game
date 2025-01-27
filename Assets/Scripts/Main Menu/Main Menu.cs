using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("Select Level");

    }
     public void TutorialButton()
    {
        SceneManager.LoadSceneAsync("Tutorial");

    }
    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync("Credits");

    }

     public void QuitGame()
    {
        Application.Quit();
    }
}
