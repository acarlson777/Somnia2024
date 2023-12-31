using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCircleLegacy : MonoBehaviour
{
    //A basic unit of the Joystick's circles:
    // - Contains both a circle's parent and child circle (if possible)

    public JoystickCircleLegacy parentCircle;
    public JoystickCircleLegacy childCircle;
    public new GameObject gameObject;
    public Vector3 joystickDirection;

    public void SetFamily(JoystickCircleLegacy parentCircle, JoystickCircleLegacy childCircle, GameObject gameObject)
    {
        this.parentCircle = parentCircle;
        this.childCircle = childCircle;
        this.gameObject = gameObject;
    }

    public void MoveRelativeToParent(Vector3 deltaDrag)
    {

        gameObject.transform.position = parentCircle.gameObject.transform.position + deltaDrag;
        if (childCircle != null)
        {
            childCircle.MoveRelativeToParent(deltaDrag);
        }
    }
}

