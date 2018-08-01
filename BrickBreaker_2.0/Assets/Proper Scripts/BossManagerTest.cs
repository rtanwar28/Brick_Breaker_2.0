using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManagerTest: MonoBehaviour 
{
    BrickManagerTest brickObj;

	// Use this for initialization
	void Start () 
    {
        brickObj = GameObject.Find("BrickManagerTest").GetComponent<BrickManagerTest>();
        StartCoroutine(SwitchTimer());
	}

    void Update()
    {
        if (brickObj.heartBrick.Count == 0)
        {
            StartCoroutine(DestroyBodyBricks());
        }
    }

    // This occurs when the heart is destroyed. Basically, dissolving the boss.
    IEnumerator DestroyBodyBricks()
    {
        for (int i = 0; i < brickObj.bodyBricks.Count; i++)
        {
            Destroy(brickObj.bodyBricks[i]);
            brickObj.bodyBricks.Remove(brickObj.bodyBricks[i]);
            yield return new WaitForSeconds(50f);
            // Updating the score
            GameObject.Find("GameCanvas").GetComponent<CanvasManager>().scoreVal = GameObject.Find("GameCanvas").GetComponent<CanvasManager>().scoreVal + (brickObj.bodyBricks.Count * 50);
            GameObject.Find("GameCanvas").GetComponent<CanvasManager>().score.text = GameObject.Find("GameCanvas").GetComponent<CanvasManager>().scoreVal.ToString("000");
        }

    }

    // Switching between the body and heart bricks
    IEnumerator SwitchTimer()
    {
        brickObj.brickSwitch = !brickObj.brickSwitch;

        yield return new WaitForSeconds(Random.Range(5f, 10f));

        SwitchBricks();
    }

    void SwitchBricks()
    {
        foreach (GameObject heart in brickObj.heartBrick)
        {
            heart.SetActive(brickObj.brickSwitch);
        }
        foreach (GameObject body in brickObj.bodyBricks)
        {
            body.GetComponent<BoxCollider>().isTrigger = brickObj.brickSwitch;
            Color color = body.GetComponent<MeshRenderer>().material.color;
            if (brickObj.brickSwitch)
                color.a = 0.4f;
            else
                color.a = 1f;
            
            body.GetComponent<MeshRenderer>().material.color = color;
        }

        StartCoroutine(SwitchTimer());
    }
}
