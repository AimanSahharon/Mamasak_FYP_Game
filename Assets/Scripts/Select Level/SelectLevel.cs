/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to load other scene

public class SelectLevel : MonoBehaviour
{
   public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void ToNasiLemakLevel()
    {
        SceneManager.LoadSceneAsync("Nasi Lemak Level");
    }
    public void ToRotiCanaiLevel()
    {
        SceneManager.LoadSceneAsync("Roti Canai Level");
    }
    public void ToCharKwayTeowLevel()
    {
        SceneManager.LoadSceneAsync("Char Kway Teow Level");
    }
     public void ToServeLevel()
    {
        SceneManager.LoadSceneAsync("Serve Level");
    }


} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To load other scenes

public class SelectLevel : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset time scale to 1 whenever a scene is loaded
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void ToNasiLemakLevel()
    {
        SceneManager.LoadSceneAsync("Nasi Lemak Level");
    }

    public void ToRotiCanaiLevel()
    {
        SceneManager.LoadSceneAsync("Roti Canai Level");
    }

    public void ToCharKwayTeowLevel()
    {
        SceneManager.LoadSceneAsync("Char Kway Teow Level");
    }

    public void ToServeLevel()
    {
        SceneManager.LoadSceneAsync("Serve Level");
    }
}
