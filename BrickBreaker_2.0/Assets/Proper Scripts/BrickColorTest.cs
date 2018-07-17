using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorTest : MonoBehaviour 
{
    BrickManagerTest bmTest;
    CanvasManager canvasManager;
    PowerupManager powerupManager;

    public int colorCtr;
    public string matName;

	// Use this for initialization
	void Start () 
    {
        bmTest = GameObject.Find("BrickManagerTest").GetComponent<BrickManagerTest>();
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
        powerupManager = GameObject.Find("Paddle").GetComponent<PowerupManager>();

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
                Vector3 brickPos = transform.localPosition;
                Destroy(gameObject);
                bmTest.DeleteFromList(gameObject);

                float generatePowerUp = Random.Range(0f, 100f);
                if(generatePowerUp < 20f)
                {
                    int selectPU = Random.Range(0, 2);
                    Instantiate(powerupManager.powerUps[selectPU], brickPos, Quaternion.identity);
                }

            }
            else
            {
                SetBrickColor(bmTest.brickColors[colorCtr]);
            }
        }
    }
}
