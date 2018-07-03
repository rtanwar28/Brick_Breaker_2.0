using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleTest : MonoBehaviour 
{
    [Range(0, 20)]
    public int speed;

    float xAxis, clampXVal;

	// Use this for initialization
	void Start () 
    {
        clampXVal = ((Camera.main.orthographicSize * Camera.main.aspect) + (transform.localScale.x / 2f)) - transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        xAxis = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector3(xAxis * speed * Time.deltaTime, 0f, 0f));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampXVal, clampXVal),
                                             transform.position.y,
                                             transform.position.z);

        }
        else
        {
            transform.Translate(Vector3.zero);
        }
	}
}
