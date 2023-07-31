using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;

    [Header("GameOver Elements")]
    public GameObject gameOverPanel;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Best: " + highScore.ToString();
        gameOverPanel.SetActive(false);
    }

    public void IncreaseScore(int numb = 1)
    {
        score += numb;
        scoreText.text = score.ToString();

        if (score > highScore) {
            PlayerPrefs.SetInt("highScore", score); 
            highScore = score;
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        //highscore speichern

        //score auf 0 setzn
        score = 0;
        scoreText.text = "0";

        //scene leeren
        gameOverPanel.SetActive(false);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        //timescale reaktivieren
        Time.timeScale = 1;
    }
}
