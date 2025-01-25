/*using System.Collections;
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
} */
using System.Collections;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public GameObject gameObjectA; // Assign GameObject A in the Inspector
    public GameObject gameObjectB; // Assign GameObject B in the Inspector
    public ParticleSystem particleEffect; // Assign your ParticleSystem in the Inspector

    private bool hasTriggered = false; // Ensure the coroutine only runs once

    void Update()
    {
        // Check if GameObject A is active and the effect hasn't already been triggered
        if (gameObjectA.activeSelf && !hasTriggered)
        {
            hasTriggered = true; // Prevent multiple triggers
            StartCoroutine(PlayEffectAndActivateB());
        }
    }

    private IEnumerator PlayEffectAndActivateB()
    {
        // Play the particle effect
        if (particleEffect != null)
        {
            particleEffect.Play();
        }

        // Wait for 5 seconds (or match this duration with your particle effect's lifetime)
        yield return new WaitForSeconds(3f);

        // Activate GameObject B
        gameObjectB.SetActive(true);
        Time.timeScale = 0;
    }
}
