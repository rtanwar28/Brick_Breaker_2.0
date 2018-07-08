using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour 
{
    public GameObject gameCanvas;
    public Text highestScore;

	// Use this for initialization
	void Start () 
    {
        highestScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString("0000");	
	}
	
	public void SetHighScore(int highScore)
    {
        PlayerPrefs.SetInt("Highscore", highScore);
        highestScore.text = highScore.ToString();
    }
}
