using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    Vector3 startHoldPos;
    Vector3 currentHoldPos;
    Vector3 deltaHoldPos;

    JoystickCircle largestCircle;
    JoystickCircle mediumCircle;
    JoystickCircle smallCircle;

    GameObject largest;
    GameObject medium;
    GameObject small;

    void Start()
    {
        largest = GameObject.Find("largest");
        medium = GameObject.Find("medium");
        small = GameObject.Find("small");

        largestCircle = largest.GetComponent<JoystickCircle>();
        mediumCircle = medium.GetComponent<JoystickCircle>();
        smallCircle = small.GetComponent<JoystickCircle>();

        largestCircle.SetFamily(null, mediumCircle, largest);
        mediumCircle.SetFamily(largestCircle, smallCircle, medium);
        smallCircle.SetFamily(mediumCircle, null, small);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            startHoldPos = Camera.main.ScreenToWorldPoint(newMousePosition);
            print("Clicked" + startHoldPos);
        } 

        if (Input.GetMouseButton(0))
        {   
            Vector3 newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            currentHoldPos = Camera.main.ScreenToWorldPoint(newMousePosition);
            print("Held" + currentHoldPos);

            deltaHoldPos = startHoldPos - currentHoldPos;
            mediumCircle.MoveRelativeToParent(-deltaHoldPos);
        }

        if (!Input.GetMouseButton(0))
        {
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }
}
