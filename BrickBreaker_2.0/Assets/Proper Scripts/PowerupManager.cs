using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour 
{
    public GameObject[] powerUps;

    CanvasManager canvasManager;

	// Use this for initialization
	void Start () 
    {
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void InvokePowerUps(string powerName)
    {
        powerName = powerName.Replace("(Clone)", "");
        Invoke(powerName, 0f);
    }

    void HeartTest()
    {
        canvasManager.PowerUpLives();
    }
}
