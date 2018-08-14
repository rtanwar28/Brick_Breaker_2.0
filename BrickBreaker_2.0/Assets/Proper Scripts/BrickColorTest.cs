using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorTest : MonoBehaviour 
{
    // Reference to other class/scripts
    BrickManagerTest bmTest;
    CanvasManager canvasManager;
    PowerupManager powerupManager;
    AudioManager getAudioManager;

    public int colorCtr;
    public string matName;

    // Use this for initialization
    void Awake()
    {
        bmTest = GameObject.Find("BrickManagerTest").GetComponent<BrickManagerTest>();
        canvasManager = GameObject.Find("GameCanvas").GetComponent<CanvasManager>();
        powerupManager = GameObject.Find("Paddle").GetComponent<PowerupManager>();
        getAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        matName = GetComponent<MeshRenderer>().sharedMaterial.name;

        SetCounter();
    }

    void SetCounter()
    {
        if(!bmTest.isBossLevel)
        {
            for (int i = 0; i < bmTest.brickColors.Count; i++)
            {
                if (bmTest.brickColors[i].name == matName)
                {
                    colorCtr = i;
                }
            }
        }
        else
        {
            colorCtr = 1;
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
            getAudioManager.audioSource.PlayOneShot(getAudioManager.brickHit);
            colorCtr--;
            canvasManager.UpdateScore();
            if(colorCtr <= 0)
            {
                Vector3 brickPos = transform.position;

                Instantiate(bmTest.brickBurst, brickPos, Quaternion.Euler(0f, 0f, 94f));

                Destroy(gameObject);

                bmTest.DeleteFromList(gameObject);

                float generatePowerUp = Random.Range(0f, 100f);
                if(generatePowerUp < 5f)
                {
                    int selectPU = Random.Range(0, 3);
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
