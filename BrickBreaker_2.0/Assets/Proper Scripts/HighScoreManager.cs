using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoreManager : MonoBehaviour 
{
    public GameObject gameCanvas;
    public Text highestScore;
    public int highScore_Int;

    GameManager gameManager;

    //--- For File IO

    // Path of the text file
    public string filePath;
    public string fileData;

    StreamReader reader;
    StreamWriter writer;

    public bool isSetScore;

	// Use this for initialization
	void Awake () 
    {
        // Get the file path
        filePath = Application.dataPath + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar + "ScoreKeeper.txt";

        // Reading the data in the text file
        fileData = File.ReadAllText(filePath);

        // Setting the int value based on the file data
        highScore_Int = int.Parse(fileData);

        highestScore.text = highScore_Int.ToString("0000");

        isSetScore = false;

        gameManager = GetComponent<GameManager>();
	}

    private void Update()
    {
        if(isSetScore)
        {
            highScore_Int = gameManager.finalScore;

            highestScore.text = highScore_Int.ToString("0000");

            UpdateFile(highScore_Int.ToString());
        }
    }

    public void UpdateFile(string scoreString)
    {
        
        File.Create("filePath").Dispose();
        // write in to the file and display
        writer = new StreamWriter(filePath, false);

        writer.Write(scoreString);

        writer.Close();

        isSetScore = false;
    }
}
