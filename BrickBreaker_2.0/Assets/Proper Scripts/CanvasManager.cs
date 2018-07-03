using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour 
{
    Text score, lives;

    int scoreVal, livesVal;

    public GameObject gameOverPanel, nextLevelPanel, pausePanel;

    public bool isPause;

	// Use this for initialization
	void Start () 
    {
        score = GameObject.Find("Score_Val").GetComponent<Text>();
        lives = GameObject.Find("Lives_Val").GetComponent<Text>();
        livesVal = 5;
        isPause = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(livesVal <= 0)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;
            gameOverPanel.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
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
}
