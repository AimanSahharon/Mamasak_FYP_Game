using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //to allow other script to access
    public GameObject gameOverUI;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI resultText;
    int score = 0;
    int highscore = 0;
    int lives = 3; 
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0); //set high score as 0 by default
        scoreText.text = score.ToString() + " Customers";
        highscoreText.text = "High Score: " + highscore.ToString();
        livesText.text = lives.ToString() + " Lives";
        resultText.text = score.ToString() + " Customers";
    }

    public void AddCustomer()
    {
        score += 1;
        scoreText.text = score.ToString() + " Customers";
        resultText.text = score.ToString() + " Customers";
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        

    }

    public void ReduceLives()
{
    lives -= 1;
    livesText.text = lives.ToString() + " Lives";

    if (lives <= 0)
    {
        Time.timeScale = 0; // Pause the game
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show the Game Over screen
        }
    }
}

public void ClearHighScore()
{
    PlayerPrefs.SetInt("highscore", 0); // Reset high score to 0
    highscore = 0; // Update the highscore variable
    highscoreText.text = "High Score: " + highscore.ToString(); // Update the UI
    Debug.Log("High score cleared!");
}
}
