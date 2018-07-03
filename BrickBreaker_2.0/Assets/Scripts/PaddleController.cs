using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour 
{
    Rigidbody paddleRb;

    [Range (0,20)]
    public int speed;

    float xAxis;

    // Use this for initialization
    void Start () 
    {
        paddleRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        xAxis = Input.GetAxis("Horizontal");

        if (xAxis != 0)
        {
            paddleRb.velocity = new Vector3(xAxis * speed, 0f, 0f);
        }
        else
        {
            paddleRb.velocity = Vector3.zero;
        }
	}
}
