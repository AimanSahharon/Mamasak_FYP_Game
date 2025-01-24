using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMesh Pro

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float initialTime; // Store the initial timer value
    [SerializeField] GameObject gameoverMenu;

    private float remainingTime;

    void Start()
    {
        // Initialize the timer with the initial value
        remainingTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Only update the timer if the game is not paused
        if (!PauseMenu.IsPaused)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0; // Set timer to 0 so it doesn't count backwards
                // Add what happens after timer is over
                gameoverMenu.SetActive(true);
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Method to restart the timer
    public void RestartTimer()
    {
        remainingTime = initialTime; // Reset the timer
        gameoverMenu.SetActive(false); // Hide the game over menu
    }
}
