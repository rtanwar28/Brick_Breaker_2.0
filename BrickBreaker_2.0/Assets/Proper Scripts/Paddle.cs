using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Range(0,10)]
    public float paddleSpeed;
    float clampXVal;

    private Vector3 paddlePos;

    public bool movePaddle;

	// Use this for initialization
	void Start () 
    {
        movePaddle = true;
        paddlePos = transform.position;
        // Clamping the paddle along the x-axis based in the orthographic view of the camera.
        clampXVal = ((Camera.main.orthographicSize * Camera.main.aspect) + (transform.localScale.x / 2f)) - transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // The paddle movement can start when the bool 'movePaddle' is true.
        if (movePaddle)
        {
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            paddlePos = new Vector3(Mathf.Clamp(xPos, -clampXVal, clampXVal), transform.position.y, transform.position.z);
            transform.position = paddlePos;
        }
	}
}
