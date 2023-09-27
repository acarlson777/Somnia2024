using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCircle : MonoBehaviour
{
    public JoystickCircle parentCircle;
    public JoystickCircle childCircle;
    public GameObject gameObject;
    public Vector3 joystickDirection;

    float joystickOffset = 1.7f;


    public JoystickCircle()
    {

    }

    public void SetFamily(JoystickCircle parentCircle, JoystickCircle childCircle, GameObject gameObject)
    {
        this.parentCircle = parentCircle;
        this.childCircle = childCircle;
        this.gameObject = gameObject;
    }

    public void MoveRelativeToParent(Vector3 deltaDrag)
    {
        Vector3 parentCircleSizeDividedByTwo = parentCircle.gameObject.transform.localScale / 2;
        joystickDirection = DivideVector3(deltaDrag, parentCircleSizeDividedByTwo);
        //gameObject.transform.position = parentCircle.gameObject.transform.position + MultiplyVector3(parentCircleSizeDividedByTwo, joystickDirection);
        gameObject.transform.position = parentCircle.gameObject.transform.position + MultiplyVector3(parentCircle.gameObject.transform.localScale * joystickOffset, joystickDirection);
        if (childCircle != null)
        {
            childCircle.MoveRelativeToParent(deltaDrag);
        }
    }


    private Vector3 DivideVector3(Vector3 firstVector, Vector3 secondVector)
    {
        Vector3 finalVector = new Vector3(firstVector.x / secondVector.x, firstVector.y / secondVector.y, firstVector.z / secondVector.z);
        return finalVector;
    }


    private Vector3 MultiplyVector3(Vector3 firstVector, Vector3 secondVector)
    {
        Vector3 finalVector = new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
        return finalVector;
    }

    private Vector3 ClipVectorToAnother(Vector3 firstVector, Vector3 secondVector)
    {
        Vector3 finalVector = new Vector3(Mathf.Min(firstVector.x, secondVector.x), Mathf.Min(firstVector.y, secondVector.y), Mathf.Min(firstVector.z, secondVector.z));
        return finalVector;
    }
}

