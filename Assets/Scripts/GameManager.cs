using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public bool gameIsOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = score.ToString();
    }

    public void UpdateLives()
    {
        if (gameIsOver == false)
        {
            lives--;
            livesText.text = "�����: " + lives;

            if (lives == 0)
            {
                GameOver();
            }
        }
       
    }

    public void GameOver()
    { 
        gameIsOver = true;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
