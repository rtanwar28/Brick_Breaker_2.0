using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColor : MonoBehaviour 
{
    public enum SetMyColor
    {
        red_EC0000,
        blue_0915CF,
        green_00B706,
        yellow_FBE500,
        orange_FF8B0B,
        purple_9305CB
    };

    // Reference to Enum
    public SetMyColor setMyColor;

    string[] colorCode;

    // To store the enum value in string format
    string colorName;

    // To set a new color
    Color newColor;

    int ctr;

    BrickManager brickManager;

	// Use this for initialization
	void Awake () 
    {
        brickManager = GameObject.Find("BrickManager").GetComponent<BrickManager>();

        colorCode = System.Enum.GetNames(typeof(SetMyColor));
        SetCounter();
        SetBrickColor();
	}

    public void ReduceCounter()
    {
        // reduce ctr by 1
        ctr--;
        // call the set brick color if the ctr is not <=0.
        if(ctr >= 0)
        {
            SetBrickColor(); 
        }
    }
	
	void SetBrickColor()
    {
        // Setting enum value to string format
        colorName = colorCode[ctr];
        // Getting the index of the '_' from the string.
        int index = colorName.IndexOf('_');
        // Removing the characters till (index+1)
        string hexCode = colorName.Remove(0, index + 1);
        // Passing the hexCode 
        ColorUtility.TryParseHtmlString("#"+hexCode, out newColor);
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    void SetCounter()
    {
        for (int i = 0; i < colorCode.Length;i++)
        {
            if (setMyColor.ToString() == colorCode[i])
                ctr = i;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Ball")
        {
            ctr--;

            if(ctr<0)
            {
                Destroy(gameObject);
                brickManager.DeleteFromList(gameObject);
            }
            else
            {
                SetBrickColor();
            }
        }
    }
}

/* NOTE : 
 * ColorUtility : A collection of color functions.
 * TryParseHtmlString: Allows for passing a string to a color. No other color function helps convert string to color type.
 */