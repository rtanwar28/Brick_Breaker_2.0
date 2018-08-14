using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsDestroyer : MonoBehaviour 
{
    public GameObject[] cloneObjects;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(DestroyPrefabs());
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    IEnumerator DestroyPrefabs()
    {
        yield return new WaitForSeconds(30f);

        cloneObjects = GameObject.FindGameObjectsWithTag("powerUp");

        for (int i = 0; i < cloneObjects.Length;i++)
        {
            Destroy(cloneObjects[i]);
        }

        StartCoroutine(DestroyPrefabs());
    }
}
