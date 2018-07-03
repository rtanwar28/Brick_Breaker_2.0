using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour 
{
    [Range(0, 20)]
    public float ballVelocity;
    public bool isLaunched;

    public Rigidbody ballRB;
    public GameObject paddle;

	// Use this for initialization
	void Start () 
    {
        isLaunched = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLaunched = true;
        }

        if(isLaunched)
        {
            //ballRB.AddForce(new Vector3(ballVelocity, ballVelocity, 0f));
            ballRB.velocity = new Vector3(ballVelocity, ballVelocity, 0f);
            //ballRB.AddForce(new Vector3(ballVelocity, ballVelocity, 0f));
        }
        else
        {
            transform.position = new Vector3(paddle.transform.position.x, transform.position.y, 0f);

        }
	}
}


//float random = Random.Range(20, 160);
//Debug.Log("Random: " + random + " round off: " + Mathf.Round(random));