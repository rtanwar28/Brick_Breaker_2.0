using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour 
{
    public int levelCtr = 1;
    public int maxLevel = 5;

    public GameObject gameCanvas, nextLevelPanel, mainMenuCanvas;

    AudioManager getAudioManager;
    TextFileManager fileManager;
   // BrickManagerTest brickManager;

    int highScoreInt;
    private object yPaddle;

    public bool isGameOver, goToMenu;
    public int finalScore;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        isGameOver = false;
        goToMenu = false;

        // Getting reference to the audio manager script
        getAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

       // brickManager = GameObject.Find("BrickManagerTest").GetComponent<BrickManagerTest>();
    }

    // if mouse is hovering
    public void OnMouseOver()
    {
        getAudioManager.audioSource.PlayOneShot(getAudioManager.mouseHover);
    }

    // if mouse is clicked
    public void OnMouseDown()
    {
        getAudioManager.audioSource.PlayOneShot(getAudioManager.mouseClick);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

        finalScore = gameCanvas.GetComponent<CanvasManager>().scoreVal;

        if (finalScore > GetComponent<HighScoreManager>().highScore_Int && isGameOver)
        {
            GetComponent<HighScoreManager>().isSetScore = true;

            isGameOver = false;
        }

        Time.timeScale = 1f;

        ResetGameValues();
    }

    public void PlayGame()
    {
        gameCanvas.GetComponent<CanvasManager>().isFinalLevel = false;
        gameCanvas.GetComponent<CanvasManager>().pausePanel.SetActive(false);

        mainMenuCanvas.SetActive(false);

        if(!gameCanvas.activeInHierarchy)
        {
            gameCanvas.SetActive(true);
        }

        SceneManager.LoadScene("Level_" + levelCtr);
        levelCtr++;
    }

    public void NextLevel()
    {
        GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = true;
        gameCanvas.GetComponent<CanvasManager>().isRestartScore = true;
        SceneManager.LoadScene("Level_" + levelCtr);
        levelCtr++;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().isPause = false;
        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        gameCanvas.GetComponent<CanvasManager>().scoreVal = gameCanvas.GetComponent<CanvasManager>().restartScore;
        gameCanvas.GetComponent<CanvasManager>().score.text = gameCanvas.GetComponent<CanvasManager>().restartScore.ToString("000");

        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().isPause = false;
        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().pausePanel.SetActive(false);
        // This line is what makes resume and restart different
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetGameValues()
    {
        levelCtr = 1;
        gameCanvas.GetComponent<CanvasManager>().gameOverPanel.SetActive(false);
        gameCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        gameCanvas.GetComponent<CanvasManager>().scoreVal = 0;
        gameCanvas.GetComponent<CanvasManager>().score.text = gameCanvas.GetComponent<CanvasManager>().scoreVal.ToString();
        gameCanvas.GetComponent<CanvasManager>().livesVal = 10;
        gameCanvas.GetComponent<CanvasManager>().lives.text = gameCanvas.GetComponent<CanvasManager>().livesVal.ToString();
       // gameCanvas.GetComponent<CanvasManager>().isPause = false;

    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator ReloadLevel()
    {
        // Finding the paddle and ball gameobject's
        GameObject myPaddle = GameObject.Find("Paddle");
        GameObject myBall  = GameObject.Find("Ball");

        // Setting the bool to false so the paddle doesn't move
        myPaddle.GetComponent<Paddle>().movePaddle = false;
        // Setting the ball a child of the paddle.
        myBall.transform.SetParent(myPaddle.transform);
        myBall.transform.rotation = Quaternion.Euler(0, 0, 0);
        // Setting the position of the paddle and ball.
        myPaddle.transform.position = new Vector3(-0.07f, -4.32f, -0.2f);

        myBall.GetComponent<Ball>().SetBallProperties(myBall);

        //myBall.transform.localPosition = new Vector3(0.33f, 5f, 0f);
   
        // Setting is ball bool to false and isKinematic to true so it does not move
        myBall.GetComponent<Ball>().isLaunched = false;
        myBall.GetComponent<Rigidbody>().isKinematic = true;

        // Wait for 1 second before the paddle can move
        yield return new WaitForSeconds(1);
        myPaddle.GetComponent<Paddle>().movePaddle = true;
    }
}

//--USE THIS IF NOTHING GOES RIGHT--    //myBall.transform.position = new Vector3(myPaddle.transform.position.x, myPaddle.transform.position.y + (myPaddle.GetComponent<BoxCollider>().size.y * myPaddle.transform.localScale.y / 2f) + (myBall.GetComponent<SphereCollider>().center.y * myBall.transform.localScale.y / 2f) , 0f);
