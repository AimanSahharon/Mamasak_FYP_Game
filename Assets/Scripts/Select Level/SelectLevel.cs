using System.Collections;
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


}
