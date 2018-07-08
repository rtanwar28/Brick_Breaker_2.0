using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour 
{
    public Text score, lives, finalScore;

    public int scoreVal, livesVal, restartScore;

    public GameObject gameOverPanel, nextLevelPanel, pausePanel;

    public bool isPause, isRestartScore;

	// Use this for initialization
	void Start () 
    {
        score = GameObject.Find("Score_Val").GetComponent<Text>();
        lives = GameObject.Find("Lives_Val").GetComponent<Text>();

        isPause = false;
        restartScore = scoreVal;
        isRestartScore = true;

        SetValues();
	}

    void SetValues()
    {
        livesVal = 1;
        lives.text = livesVal.ToString();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(livesVal <= 0)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;
            gameOverPanel.SetActive(true);

            finalScore.text = "You Scored: " + scoreVal;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if(isRestartScore)
        {
            restartScore = scoreVal;
            isRestartScore = false;
        }
	}

    public void UpdateScore()
    {
        scoreVal += 50;
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
