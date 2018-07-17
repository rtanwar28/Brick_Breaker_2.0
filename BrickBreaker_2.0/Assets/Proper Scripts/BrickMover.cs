using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMover : MonoBehaviour
{
    // Transform values of the icon
    Transform icon;
    // Declaring the variables for the icon animation
    float min, max, mul;
    public float distMin, distMax, pingPongSpeed;

    public bool invert;

    // Setting the minimum and maximum distance and setting the rotation of the icon.
    void Start()
    {
        icon = this.transform;
        min = icon.localPosition.x - distMin;
        max = icon.localPosition.x + distMax;
        mul = 1f;
    }

    // Updating the rotation and position of the icon every frame.
    void Update()
    {
        if (invert)
            icon.localPosition = new Vector3((Mathf.PingPong(Time.time * pingPongSpeed, max - min) + min).Remap(min, max, max, min),
                                         icon.localPosition.y, icon.localPosition.z);

        else
            icon.localPosition = new Vector3(Mathf.PingPong(Time.time * pingPongSpeed, max - min) + min,
                                         icon.localPosition.y, icon.localPosition.z);


    }
}
