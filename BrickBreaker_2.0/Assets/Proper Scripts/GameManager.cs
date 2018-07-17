using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public int levelCtr = 1;
    public GameObject gameCanvas, nextLevelPanel, mainMenuCanvas;

    //public HighScoreManager highScoreManager;
    public Text highestScore;
    private object yPaddle;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(highestScore);
        highestScore = GameObject.Find("HighestScore").GetComponent<Text>();
        highestScore.text = PlayerPrefs.GetInt("HighestScore", 0).ToString("0000");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        int score = gameCanvas.GetComponent<CanvasManager>().scoreVal;

        if (score > PlayerPrefs.GetInt("HighestScore", 0))
        {
            PlayerPrefs.SetInt("HighestScore", score);
            highestScore.text = score.ToString();
        }

        Time.timeScale = 1f;

        ResetGameValues();
    }

    public void PlayGame()
    {
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
        gameCanvas.GetComponent<CanvasManager>().livesVal = 5;
        gameCanvas.GetComponent<CanvasManager>().lives.text = gameCanvas.GetComponent<CanvasManager>().livesVal.ToString();
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
        // Setting the position of the paddle and ball.
        myPaddle.transform.position = new Vector3(-0.07f, -4.32f, -0.2f);
        myBall.transform.position = new Vector3(myPaddle.transform.position.x, myPaddle.transform.position.y + (myPaddle.GetComponent<BoxCollider>().size.y * myPaddle.transform.localScale.y / 2f) + (myBall.GetComponent<SphereCollider>().center.y * myBall.transform.localScale.y / 2f) , 0f);
        // Setting is ball bool to false and isKinematic to true so it does not move
        myBall.GetComponent<Ball>().isLaunched = false;
        myBall.GetComponent<Rigidbody>().isKinematic = true;

        // Wait for 1 second before the paddle can move
        yield return new WaitForSeconds(1);
        myPaddle.GetComponent<Paddle>().movePaddle = true;
    }


}
