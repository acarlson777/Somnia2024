using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCircle : MonoBehaviour
{
    public JoystickCircle parentCircle;
    public JoystickCircle childCircle;
    public RectTransform rt;

    public void Start()
    {
        rt = GetComponent<RectTransform>();
    }


    public void SetFamily(JoystickCircle parentCircle, JoystickCircle childCircle)
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
