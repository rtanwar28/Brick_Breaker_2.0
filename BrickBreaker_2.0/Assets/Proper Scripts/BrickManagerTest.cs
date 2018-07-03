using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManagerTest : MonoBehaviour 
{
    public List<Material> brickColors;
    public List<GameObject> bricksList;

    CanvasManager canvasManager;

    public AudioSource hitAudio;

	// Use this for initialization
	void Start () 
    {
        bricksList.AddRange(GameObject.FindGameObjectsWithTag("bricks"));
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
	}

    void Update()
    {
        if(bricksList.Count == 0)
        {
            GameObject.Find("Paddle").GetComponent<Paddle>().movePaddle = false;
            canvasManager.nextLevelPanel.SetActive(true);
        }
        else
        {
            canvasManager.nextLevelPanel.SetActive(false);
        }
    }

    public void DeleteFromList(GameObject deleteBrick)
    {
        if (bricksList.Contains(deleteBrick))
        {
            bricksList.Remove(deleteBrick);
        }
    }
	
	
}
