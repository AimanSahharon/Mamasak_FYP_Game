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


}
