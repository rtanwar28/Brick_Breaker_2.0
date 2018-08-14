using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsManager : MonoBehaviour 
{
    public GameObject previousBtn, nextBtn;

    public GameObject[] myPanels;

    public GameObject currentPanel, prevPanel, nextPanel;

    public int ctr;

	// Use this for initialization
	void Start () 
    {
        ctr = 0;

        currentPanel = myPanels[ctr];
        nextPanel = myPanels[ctr + 1];

        if(ctr<= 0)
        {
            previousBtn.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentPanel = myPanels[ctr];

        if (ctr <= 0)
        {
            previousBtn.SetActive(false);
        }
        else if(ctr > 0 && ctr < (myPanels.Length - 1))
        {
            previousBtn.SetActive(true);
            nextBtn.SetActive(true);
        }
        else if(ctr >= (myPanels.Length-1))
        {
            nextBtn.SetActive(false);
        }



        if (ctr < (myPanels.Length - 1))
        {
            nextPanel = myPanels[ctr + 1];
        }

        if (ctr > 0)
        {
            prevPanel = myPanels[ctr - 1];
        }
	}

    public void ShowNext()
    {
        currentPanel.SetActive(false);

        ctr++;

        nextPanel.SetActive(true);
    }

    public void ShowPrev()
    {
        currentPanel.SetActive(false);

        prevPanel.SetActive(true);

        ctr--;
    }
}
