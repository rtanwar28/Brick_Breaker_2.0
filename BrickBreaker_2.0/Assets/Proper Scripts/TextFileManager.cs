using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextFileManager : MonoBehaviour
{
    // Path of the text file
    public string filePath;
    public string fileData;

    StreamReader reader;
    StreamWriter writer;

    // Use this for initialization
    void Start()
    {
        // Get the file path
        filePath = Application.dataPath + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar + "ScoreKeeper.txt";

        // Reading the data in the text file
        fileData = File.ReadAllText(filePath);

        Debug.Log("File Data: " + fileData);

        Debug.Log("File Path: " + filePath);

        //// Reading the file
        //reader = new StreamReader(filePath + "ScoreKeeper.txt");
        //Debug.Log("Read to end: " + reader.ReadToEnd());

        //reader.Close();
    }


    // Update is called once per frame
    public void UpdateFile(string scoreString)
    {
        File.Create("filePath").Dispose();
        // write in to the file and display
        writer = new StreamWriter(filePath, true);

        writer.WriteLine(scoreString);

        writer.Close();

    }
}
