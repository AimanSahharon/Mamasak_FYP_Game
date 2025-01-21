using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //import textmesh pro

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameoverMenu;

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
                remainingTime = 0; //set timer to 0 so it doesn't count backwards
                //add what happens after timer is over
                gameoverMenu.SetActive(true);
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
