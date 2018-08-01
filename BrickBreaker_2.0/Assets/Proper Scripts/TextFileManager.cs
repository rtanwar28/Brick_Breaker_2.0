using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextFileManager : MonoBehaviour
{
    // Path of the text file
    string filePath;

    public string writeHere;

    StreamReader reader;
    StreamWriter writer;

    // Use this for initialization
    void Start()
    {
        // filePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "/Assets/Resources/ScoreKeeper.txt";

        filePath = "Assets/Resources/ScoreKeeper.txt";

        Debug.Log("File Path: " + filePath);
        Debug.Log("Application Persitant Data Path: " + Application.persistentDataPath);
        Debug.Log("Path Directory Seperator Char: " + Path.DirectorySeparatorChar);

        reader = new StreamReader(filePath);
        Debug.Log("Read to end: " + reader.ReadToEnd());


    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("i wrote: " + writeHere);
            // write in to the file and display
            writer = new StreamWriter(filePath, true);
           // writer.WriteLine(writeHere);
            File.WriteAllText(filePath, writeHere);

        }
    }
}
