using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManagerTest : MonoBehaviour 
{
    public List<Material> brickColors;
    // For normal levels
    public List<GameObject> bricksList;

    // For boss levels
    public List<GameObject> bodyBricks, heartBrick;
    public bool brickSwitch;

    // To check if boss level or not
    public bool isBossLevel;

    CanvasManager canvasManager;
    GameManager gameManager;

    public ParticleSystem brickBurst;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if ((gameManager.levelCtr - 1) > 0)
        {

            if ((gameManager.levelCtr - 1) % 5 == 0)
            {
                isBossLevel = true;
            }
            else
                isBossLevel = false;
        }
    }

    // Use this for initialization
    void Start () 
    {
        if (!isBossLevel)
        {
            bricksList.AddRange(GameObject.FindGameObjectsWithTag("bricks"));
        }
        else
        {
            bodyBricks.AddRange(GameObject.FindGameObjectsWithTag("body_bricks"));
            heartBrick.AddRange(GameObject.FindGameObjectsWithTag("heart_bricks"));

            foreach (GameObject heart in heartBrick)
            {
                heart.SetActive(brickSwitch);
            }
        }

        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
	}

    void Update()
    {
        if (bricksList.Count == 0 && !isBossLevel)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;

            canvasManager.nextLevelPanel.SetActive(true);
        }

        else if (bodyBricks.Count == 0 && isBossLevel)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;
            canvasManager.isFinalLevel = true;
        }

        else
        {
            canvasManager.nextLevelPanel.SetActive(false);
        }
    }

    public void DeleteFromList(GameObject deleteBrick)
    {
        // Normal levels
        if (bricksList.Contains(deleteBrick))
        {
            bricksList.Remove(deleteBrick);
        }

        // Boss Levels
        else if (bodyBricks.Contains(deleteBrick))
        {
            bodyBricks.Remove(deleteBrick);
        }
        else if (heartBrick.Contains(deleteBrick))
        {
            heartBrick.Remove(deleteBrick);
        }
    }
	
	
}
