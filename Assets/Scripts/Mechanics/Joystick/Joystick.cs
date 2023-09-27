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

        if (Input.GetMouseButton(0))
        {   
            currentHoldPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) * sensitivity;

            deltaHoldPos = currentHoldPos - startHoldPos;

            if (deltaHoldPos.magnitude > joystickConstant)
            {
                deltaHoldPos = deltaHoldPos.normalized * joystickConstant;
            }

            JoystickInput.joystickDirection = deltaHoldPos / joystickConstant;
            //JoystickInput.worldOrientedJoystickDirection =      
            mediumCircle.MoveRelativeToParent(deltaHoldPos);
        }

        if (!Input.GetMouseButton(0))
        {
            JoystickInput.joystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }

    private Vector3 RotateVector2ForVector3(Vector3 vector, float angle)
    {
        //Mathf.Cos(45*Mathf.Deg2Rad) - Mathf.Sin(45*Mathf.Deg2Rad), Mathf.Sin(45*Mathf.Deg2Rad) + Mathf.Cos(45*Mathf.Deg2Rad), JoystickInput.joystickDirection.z);
        //Rotate Vector3 using the vector2 formula and return the vector (ignoring the z axis);
        return new Vector3();
    }
}
