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
    AudioManager getAudioManager;

    Vector3 originalPos, originalScale;

    // Use this for initialization
    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        paddleScript = GameObject.Find("Paddle").GetComponent<Paddle>();
        getAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        originalPos = transform.localPosition;
        originalScale = transform.localScale;
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

        if(isLaunched)
        {
            // Rotating the ball
            transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            canvasManager.UpdateLives();

            StartCoroutine(gameManager.ReloadLevel());
            getAudioManager.audioSource.PlayOneShot(getAudioManager.ballRespawn);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Paddle")
        {
            getAudioManager.audioSource.PlayOneShot(getAudioManager.paddleHit);
        }
    }

    public void SetBallProperties(GameObject respawnedBall)
    {
        respawnedBall.transform.localPosition = originalPos;
        respawnedBall.transform.localScale = originalScale;
    }

}
