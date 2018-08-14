using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour 
{
    public Text score, lives, finalScore, gameOverHeading;

    public int scoreVal, livesVal, restartScore;

    public GameObject gameOverPanel, nextLevelPanel, pausePanel;

    public bool isPause, isRestartScore, isFinalLevel;

    // Reference to other scripts
    public GameManager gameManager;
    public BrickManagerTest brickManager;

	// Use this for initialization
	void Start () 
    {
        score = GameObject.Find("Score_Val").GetComponent<Text>();
        lives = GameObject.Find("Lives_Val").GetComponent<Text>();

        isPause = false;
        restartScore = scoreVal;
        isRestartScore = true;
        isFinalLevel = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        SetValues();
	}

    void SetValues()
    {
        livesVal = 10;
        lives.text = livesVal.ToString();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (livesVal <= 0)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;
            gameOverPanel.SetActive(true);
            gameManager.isGameOver = true;
            finalScore.text = "You Scored: " + scoreVal;
            gameOverHeading.text = "Game Over";
            gameOverHeading.color = Color.white;
        }

        if(isFinalLevel)
        {
            gameOverPanel.SetActive(true);
            gameManager.isGameOver = true;
            finalScore.text = "You Score: " + scoreVal;
            gameOverHeading.text = "That's all folks!";
            gameOverHeading.color = new Color(180f, 248f, 0f);
            isFinalLevel = false;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().audioSource.Pause();
        }

        if(isRestartScore)
        {
            restartScore = scoreVal;
            isRestartScore = false;
        }
	}

    public void UpdateScore()
    {
        scoreVal += 5;
        score.text = scoreVal.ToString("000");
    }

    public void UpdateLives()
    {
        livesVal -= 1;
        lives.text = livesVal.ToString();
    }

    public void PowerUpLives()
    {
        livesVal += 1;
        lives.text = livesVal.ToString();
    }
}
