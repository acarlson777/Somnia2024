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
#if UNITY_EDITOR
        UnityEditorJoystickLogic();
        return;
#endif

        MobileJoystickLogic();
    }

    private Vector3 RotateVector2ForVector3(Vector3 vector, float angle)
    {
        return new Vector3(
                           Mathf.Cos(angle*Mathf.Deg2Rad)*vector.x - Mathf.Sin(angle*Mathf.Deg2Rad)*vector.y,
                           JoystickInput.joystickDirection.z,
                           Mathf.Sin(angle*Mathf.Deg2Rad)*vector.x + Mathf.Cos(angle*Mathf.Deg2Rad)*vector.y
                           );
    }

    private void UnityEditorJoystickLogic()
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
            JoystickInput.worldOrientedJoystickDirection = RotateVector2ForVector3(JoystickInput.joystickDirection, -Camera.main.transform.rotation.eulerAngles.y);
            mediumCircle.MoveRelativeToParent(deltaHoldPos);
        }

        if (!Input.GetMouseButton(0))
        {
            JoystickInput.joystickDirection = Vector3.zero;
            JoystickInput.worldOrientedJoystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }
    
    private void MobileJoystickLogic()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startHoldPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0) * sensitivity;

                this.gameObject.transform.position = startHoldPos;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentHoldPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0) * sensitivity;

                deltaHoldPos = currentHoldPos - startHoldPos;

                if (deltaHoldPos.magnitude > joystickConstant)
                {
                    deltaHoldPos = deltaHoldPos.normalized * joystickConstant;
                }

                JoystickInput.joystickDirection = deltaHoldPos / joystickConstant;
                JoystickInput.worldOrientedJoystickDirection = RotateVector2ForVector3(JoystickInput.joystickDirection, -Camera.main.transform.rotation.eulerAngles.y);
                mediumCircle.MoveRelativeToParent(deltaHoldPos);
            }
        }

        if (Input.touchCount == 0)
        {
            JoystickInput.joystickDirection = Vector3.zero;
            JoystickInput.worldOrientedJoystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }
}


