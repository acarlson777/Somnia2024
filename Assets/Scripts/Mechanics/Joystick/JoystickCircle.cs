using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCircle : MonoBehaviour
{
    public JoystickCircle parentCircle;
    public JoystickCircle childCircle;
    public new GameObject gameObject;
    public Vector3 joystickDirection;

    public void SetFamily(JoystickCircle parentCircle, JoystickCircle childCircle, GameObject gameObject)
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
