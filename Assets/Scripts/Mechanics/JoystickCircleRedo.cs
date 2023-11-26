using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCircleRedo : MonoBehaviour
{
    public JoystickCircleRedo parentCircle;
    public JoystickCircleRedo childCircle;
    public RectTransform rt;

    public void Start()
    {
        rt = GetComponent<RectTransform>();
    }


    public void SetFamily(JoystickCircleRedo parentCircle, JoystickCircleRedo childCircle)
    {
        this.parentCircle = parentCircle;
        this.childCircle = childCircle;
    }

    public void MoveRelativeToParent(Vector2 deltaDrag)
    {
        rt.anchoredPosition = parentCircle.rt.anchoredPosition + deltaDrag;
        if (childCircle != null)
        {
            childCircle.MoveRelativeToParent(deltaDrag);
        }
    }
}
