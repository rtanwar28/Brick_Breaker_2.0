using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorTest : MonoBehaviour 
{
    BrickManagerTest bmTest;
    CanvasManager canvasManager;

    public int colorCtr;
    public string matName;



	// Use this for initialization
	void Start () 
    {
        bmTest = GameObject.Find("BrickManagerTest").GetComponent<BrickManagerTest>();
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();

        matName = GetComponent<MeshRenderer>().sharedMaterial.name;

        SetCounter();
	}

    void SetCounter()
    {
        for (int i = 0; i < bmTest.brickColors.Count;i++)
        {
            if(bmTest.brickColors[i].name == matName)
            {
                colorCtr = i;
            }
        }
    }

    void SetBrickColor(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Ball")
        {
            bmTest.hitAudio.Play();
            colorCtr--;
            canvasManager.UpdateScore();
            if(colorCtr < 0)
            {
                Destroy(gameObject);
                bmTest.DeleteFromList(gameObject);
            }
            else
            {
                SetBrickColor(bmTest.brickColors[colorCtr]);
            }
        }
    }
}
