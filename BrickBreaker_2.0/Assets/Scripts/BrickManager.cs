using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public List<GameObject> brickList;

	// Use this for initialization
	void Start () 
    {
        brickList.AddRange(GameObject.FindGameObjectsWithTag("brick"));
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void DeleteFromList(GameObject deleteBrick)
    {
        if(brickList.Contains(deleteBrick))// && deleteBrick.GetComponent<BrickColor>().ctr < 0)
        {
            brickList.Remove(deleteBrick);
        }
    }
}
