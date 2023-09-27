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

    public float joystickConstant;
    public int sensitivity;

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
            startHoldPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) * sensitivity;
            
            this.gameObject.transform.position = startHoldPos;
        } 

            // move joystick to tap on left half of screen
            if (newNewMousePosition.x <= Screen.width / 2)
            {
                this.gameObject.transform.position = newNewMousePosition;
            }
        }

        if (Input.GetMouseButton(0))
        {   
            currentHoldPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) * sensitivity;

            deltaHoldPos = currentHoldPos - startHoldPos;

            if (deltaHoldPos.magnitude > joystickConstant)
            {
                deltaHoldPos = deltaHoldPos.normalized * joystickConstant;
            }

            JoystickInput.joystickDirection = deltaHoldPos / joystickConstant;

            //deltaHoldPos = Quaternion.Euler(0, -45, 0) * deltaHoldPos;
            mediumCircle.MoveRelativeToParent(deltaHoldPos*2);
        }

        if (!Input.GetMouseButton(0))
        {
            JoystickInput.joystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }
}


