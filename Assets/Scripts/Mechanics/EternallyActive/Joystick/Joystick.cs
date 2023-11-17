using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    //Contains logic for Mobile and Unity Joysticks and sets the JoystickInput classes' values

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
    public bool debug;

    private uint JoystickCircleCount; // the amount of circles that we have. be sure to change to reflect the current count.
    private bool HeldDown = false;
    private RectTransform rectTransform;

    void Start()
    {
        largest = GameObject.Find("largest");
        medium = GameObject.Find("medium");
        small = GameObject.Find("small");
        JoystickCircleCount = 3; // This number should be adjusted in any case where the number of JoystickCircles change.
     

        largestCircle = largest.GetComponent<JoystickCircle>();
        mediumCircle = medium.GetComponent<JoystickCircle>();
        smallCircle = small.GetComponent<JoystickCircle>();

        largestCircle.SetFamily(null, mediumCircle, largest);
        mediumCircle.SetFamily(largestCircle, smallCircle, medium);
        smallCircle.SetFamily(mediumCircle, null, small);

        rectTransform = GetComponent<RectTransform>();
    }


    void Update()
    {
        #if UNITY_EDITOR
        if (debug)
        {
            MobileJoystickLogic();
        }
        else
        {
            UnityEditorJoystickLogic();
        }
        
        return;
        #endif

        #pragma warning disable CS0162 // Unreachable code detected
        MobileJoystickLogic();
        #pragma warning restore CS0162 // Unreachable code detected
    }

    private Vector3 RotateVector2ForVector3(Vector3 vector, float angle)
    {
        angle *= Mathf.Deg2Rad;
        return new Vector3(
                           Mathf.Cos(angle)*vector.x - Mathf.Sin(angle)*vector.y,
                           JoystickInput.joystickDirection.z,
                           Mathf.Sin(angle)*vector.x + Mathf.Cos(angle)*vector.y
                           );
    }
    private Vector2 PhysicalToVirtual(Vector2 screenPosition)

    {
        Vector2 physicalScreenSize = new Vector2(Screen.width, Screen.height);
        Vector2 virtualScreenSize = new Vector2(1920, 1080);
        Vector2 scalingFactors = virtualScreenSize / physicalScreenSize;
        return screenPosition * scalingFactors; 
    }
    private void UnityEditorJoystickLogic()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetMouseButtonDown(0))
        {

            startHoldPos = Input.mousePosition; // This is a physical Position
            Vector2 startHoldPhysical = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (startHoldPos.x > Screen.width/2) { return; }
            HeldDown = true;
           
            
            rectTransform.anchoredPosition = PhysicalToVirtual(startHoldPhysical);
        }

        if (Input.GetMouseButton(0))
        {
            if (!HeldDown) { return; }
            currentHoldPos = Input.mousePosition;
            deltaHoldPos = currentHoldPos - startHoldPos;
                
            if (deltaHoldPos.magnitude > joystickConstant)
            {
                deltaHoldPos = deltaHoldPos.normalized * joystickConstant; //* joystickConstant;
            }

            JoystickInput.joystickDirection = deltaHoldPos  / joystickConstant;
            JoystickInput.worldOrientedJoystickDirection = RotateVector2ForVector3(JoystickInput.joystickDirection, -Camera.main.transform.rotation.eulerAngles.y);
            mediumCircle.MoveRelativeToParent(deltaHoldPos/(JoystickCircleCount-1));
        }

        if (!Input.GetMouseButton(0))
        {
            HeldDown = false;
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
                startHoldPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);

                this.gameObject.transform.position = startHoldPos;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentHoldPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0);

                deltaHoldPos = currentHoldPos - startHoldPos;

                if (deltaHoldPos.magnitude > joystickConstant)
                {
                    deltaHoldPos = deltaHoldPos.normalized * joystickConstant;
                }

                JoystickInput.joystickDirection = deltaHoldPos / joystickConstant;
                JoystickInput.worldOrientedJoystickDirection = RotateVector2ForVector3(JoystickInput.joystickDirection, -Camera.main.transform.rotation.eulerAngles.y);
                mediumCircle.MoveRelativeToParent(deltaHoldPos / (JoystickCircleCount - 1));
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


