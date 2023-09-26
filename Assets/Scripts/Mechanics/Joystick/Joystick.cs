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
            Vector3 newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50);
            startHoldPos = Camera.main.ScreenToWorldPoint(newMousePosition);
            //print("Clicked" + startHoldPos);


            Vector3 newNewMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            this.gameObject.transform.position = newNewMousePosition;
        } 

        if (Input.GetMouseButton(0))
        {   
            Vector3 newMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50);
            currentHoldPos = Camera.main.ScreenToWorldPoint(newMousePosition);
            //print("Held" + currentHoldPos);

            deltaHoldPos = currentHoldPos  - startHoldPos;

            if (deltaHoldPos.magnitude > joystickConstant)
            {
                deltaHoldPos = deltaHoldPos.normalized * joystickConstant;
            }

            print(deltaHoldPos/joystickConstant);
            JoystickInput.joystickDirection = deltaHoldPos / joystickConstant;

            mediumCircle.MoveRelativeToParent(deltaHoldPos);
        }

        if (!Input.GetMouseButton(0))
        {
            JoystickInput.joystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }
}
