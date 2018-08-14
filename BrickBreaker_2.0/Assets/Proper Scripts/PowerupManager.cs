using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour 
{
    public GameObject[] powerUps;

    CanvasManager canvasManager;
    GameObject myPaddle;

    Vector3 myPaddleScale, newPaddleScale;

	// Use this for initialization
	void Start () 
    {
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
        myPaddle = GameObject.Find("Paddle");
        myPaddleScale = myPaddle.transform.localScale;
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

    void Heart()
    {
        canvasManager.PowerUpLives();
    }

    void Increase()
    {
        newPaddleScale = new Vector3(myPaddle.transform.localScale.x * 2, myPaddle.transform.localScale.y, myPaddle.transform.localScale.z);
        StartCoroutine(ScalePaddle(newPaddleScale, Random.Range(5f,10f)));
    }

    void Decrease()
    {
        newPaddleScale = new Vector3(myPaddle.transform.localScale.x / 2, myPaddle.transform.localScale.y, myPaddle.transform.localScale.z);
        StartCoroutine(ScalePaddle(newPaddleScale, Random.Range(5f, 10f)));
    }

    IEnumerator ScalePaddle(Vector3 paddleScaleX, float time)
    {
        // In the IEnumerator to scale paddle
        myPaddle.transform.localScale = Vector3.Lerp(myPaddle.transform.localScale, paddleScaleX, 2f);
        myPaddle.GetComponent<Paddle>().SetClamping();
        yield return new WaitForSeconds(5f);
        // Now returing paddle to normal
        myPaddle.transform.localScale = Vector3.Lerp(myPaddle.transform.localScale, myPaddleScale, 2f);
        myPaddle.GetComponent<Paddle>().SetClamping();
    }
}
