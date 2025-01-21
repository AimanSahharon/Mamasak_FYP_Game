using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
   public GameObject gameObjectA; // Assign GameObject A in the Inspector
 public GameObject gameObjectB; // Assign GameObject B in the Inspector

    void Update()
    {
        // Check if GameObject A is active
        if (gameObjectA.activeSelf)
        {
            // Start the coroutine to activate GameObject B after 3 seconds
            StartCoroutine(ActivateGameObjectB());
        }
    }

    private IEnumerator ActivateGameObjectB()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Activate GameObject B
        gameObjectB.SetActive(true);

        // Stop checking repeatedly to avoid restarting the coroutine
        enabled = false; 
        PauseMenu.IsPaused = true; //pause the timer
    }
}
