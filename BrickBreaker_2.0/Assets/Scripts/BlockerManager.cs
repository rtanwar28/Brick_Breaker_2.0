using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerManager : MonoBehaviour 
{
    public enum blockState
    {
        top,
        left,
        right
    };

    public blockState state;
    float camScreenWidth, camScreenHeight, pixelToUnitsWidth, pixelToUnitsHeight;

	// Use this for initialization
	void Start () 
    {
        pixelToUnitsWidth = ((Camera.main.orthographicSize * Camera.main.aspect) + (transform.localScale.x / 2f));
        pixelToUnitsHeight = ((Camera.main.orthographicSize * Camera.main.aspect) + (transform.localScale.y / 2f));

        if(state.ToString() == "left")
        {
            LeftBlock();
        }
        else if (state.ToString() == "right")
        {
            RightBlock();
        }
        //else if (state.ToString() == "top")
        //{
        //    TopBlock();
        //}
	}

    void LeftBlock()
    {
       // Debug.Log("I am a left block");
        transform.localPosition = new Vector3(-pixelToUnitsWidth, transform.localPosition.y, transform.localPosition.z);
        //transform.localScale = new Vector3(0.5f, Screen.height/50f, 0.5f);
    }

    void RightBlock()
    {
       // Debug.Log("I am a right block");
        transform.localPosition = new Vector3(pixelToUnitsWidth, transform.localPosition.y, transform.localPosition.z);
       // transform.localScale = new Vector3(0.5f, Screen.height/50f, 0.5f);
    }

    void TopBlock()
    {
        Debug.Log("I am a top block");
        transform.localPosition = new Vector3(transform.localPosition.x, pixelToUnitsHeight, transform.localPosition.z);
        //transform.localScale = new Vector3(0.5f, Screen.width/100f, 0.5f);
    }
	
}
