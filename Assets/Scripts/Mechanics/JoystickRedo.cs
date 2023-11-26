using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRedo : MonoBehaviour
{
    private Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    private Vector2 canvasSize;
    public Canvas canvas;

    Vector2 startHoldPos;
    Vector2 currentHoldPos;
    Vector2 deltaHoldPos;

    JoystickCircleRedo largestCircle, mediumCircle, smallCircle;
    GameObject largest, medium, small;

    RectTransform rt;

    private bool HeldDown = false;
    [Range(0f, 100f)]
    public float joystickBonusPushConstant;
    [Range(0f, 100f)]
    public float joystickSnapBackConstant;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        canvasSize = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);

        largest = GameObject.Find("largest");
        medium = GameObject.Find("medium");
        small = GameObject.Find("small");

        largestCircle = largest.GetComponent<JoystickCircleRedo>();
        mediumCircle = medium.GetComponent<JoystickCircleRedo>();
        smallCircle = small.GetComponent<JoystickCircleRedo>();

        largestCircle.SetFamily(null, mediumCircle);
        mediumCircle.SetFamily(largestCircle, smallCircle);
        smallCircle.SetFamily(mediumCircle, null);
    }

    private void Update()
    {
        EditorJoystickLogic();
    }

    private void EditorJoystickLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startHoldPos = GetMousePosAsVec2();

            if (startHoldPos.x > Screen.width / 2) { return; }
            HeldDown = true;

            rt.anchoredPosition = NormalizeMousePosToCanvasSize(startHoldPos);
        }

        if (Input.GetMouseButton(0))
        {
            if (!HeldDown) { return; }
            currentHoldPos = GetMousePosAsVec2();
            deltaHoldPos = currentHoldPos - startHoldPos;
            deltaHoldPos = NormalizeMousePosToCanvasSize(deltaHoldPos);

            if (deltaHoldPos.magnitude > joystickSnapBackConstant)
            {
                deltaHoldPos = deltaHoldPos.normalized * joystickSnapBackConstant;
            }

            JoystickInput.joystickDirection = deltaHoldPos.normalized;
            JoystickInput.worldOrientedJoystickDirection = RotateVector2ForVector3(JoystickInput.joystickDirection, -Camera.main.transform.rotation.eulerAngles.y);
            mediumCircle.MoveRelativeToParent(deltaHoldPos*joystickBonusPushConstant);
        }

        if (!Input.GetMouseButton(0))
        {
            HeldDown = false;
            JoystickInput.joystickDirection = Vector3.zero;
            JoystickInput.worldOrientedJoystickDirection = Vector3.zero;
            mediumCircle.MoveRelativeToParent(Vector3.zero);
        }
    }

    private Vector2 GetMousePosAsVec2()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }


    private Vector3 RotateVector2ForVector3(Vector3 vector, float angle)
    {
        angle *= Mathf.Deg2Rad;
        return new Vector3(
                           Mathf.Cos(angle) * vector.x - Mathf.Sin(angle) * vector.y,
                           JoystickInput.joystickDirection.z,
                           Mathf.Sin(angle) * vector.x + Mathf.Cos(angle) * vector.y
                           );
    }

    private Vector2 NormalizeMousePosToCanvasSize(Vector2 mousePosVec2)
    {
        return MultiplyVector2s(DivideVector2s(mousePosVec2, screenSize), canvasSize);
    }


    private Vector2 DivideVector2s(Vector2 a, Vector2 b)
    {
        float x1, x2, y1, y2;
        x1 = a.x;
        y1 = a.y;

        x2 = b.x;
        y2 = b.y;

        return new Vector2(x1 / x2, y1 / y2);
    }

    private Vector2 MultiplyVector2s(Vector2 a, Vector2 b)
    {
        float x1, x2, y1, y2;
        x1 = a.x;
        y1 = a.y;

        x2 = b.x;
        y2 = b.y;

        return new Vector2(x1 * x2, y1 * y2);
    }
}


