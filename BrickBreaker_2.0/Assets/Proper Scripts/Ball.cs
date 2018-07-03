using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // This is velocity is required for the initial burst of force.
    public float ballInitialVelocity = 600f;

    private Rigidbody ballRb;
    public bool isLaunched;

    CanvasManager canvasManager;
    GameManager gameManager;
    Paddle paddleScript;

    // Use this for initialization
    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        paddleScript = GameObject.Find("Paddle").GetComponent<Paddle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched && paddleScript.movePaddle)
        {
            // removing the ball from the parent object i.e. paddle.
            transform.parent = null;
            isLaunched = true;
            ballRb.isKinematic = false;

            ballRb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0f));
        }
        else if(!paddleScript.movePaddle)
        {
            ballRb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canvasManager.UpdateLives();

        if (other.gameObject.tag == "Respawn")
        {
            StartCoroutine(gameManager.ReloadLevel());
        }
    }
}
