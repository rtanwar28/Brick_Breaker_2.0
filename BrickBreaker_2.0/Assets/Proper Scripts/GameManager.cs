using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public int levelCtr = 1;
    public GameObject gameCanvas, nextLevelPanel;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void MainMenu()
    {
        gameCanvas.GetComponent<CanvasManager>().gameOverPanel.SetActive(false);
        gameCanvas.SetActive(false);
        // # Note: The last change was done here for the time.timeScale.
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        if(!gameCanvas.activeInHierarchy)
        {
            gameCanvas.SetActive(true);
        }
        Debug.Log("Level is : " + levelCtr);
        SceneManager.LoadScene("Level_" + levelCtr);
        levelCtr++;
    }

    public void NextLevel()
    {
        GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = true;
        Debug.Log("Level is : " + levelCtr);
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
        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().isPause = false;
        GameObject.Find("GameCanvas").GetComponent<CanvasManager>().pausePanel.SetActive(false);
        // this line is what makes resume and restart different
        Application.LoadLevel(Application.loadedLevel);
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
        myPaddle.transform.position = new Vector3(0f, -4f, 0f);
        myBall.transform.position = new Vector3(0f, -3.3f, 0f);
        // Setting is ball bool to false and isKinematic to true so it does not move
        myBall.GetComponent<Ball>().isLaunched = false;
        myBall.GetComponent<Rigidbody>().isKinematic = true;

        // Wait for 1 second before the paddle can move
        yield return new WaitForSeconds(1);
        myPaddle.GetComponent<Paddle>().movePaddle = true;
    }


}
