using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusArrowScript : MonoBehaviour
{
    // This is the script to be attached as a component to a physical arrow that wil bounce up and down on top of focused entities
    private GameObject focus;
    public Vector3 offset;
    private bool active = false;

    // Helper varibles .. Not needed but boost performance a bit
    private MeshRenderer meshRenderer;

    void Update()
    {
        if (!active) return;
        gameObject.transform.position = focus.transform.position + offset + new Vector3(0,GetBouncePosition(Time.time),0);
    }
    public void SetFocus(GameObject focus)
    {
        if ((focus != null) != active)
        {
            if (active)
            {
                // set mesherenderr active to true
                //meshRenderer = false
            }
            else
            {
                // set it to false
            }
        }
        active = focus != null;
        if (!active) return;
        if (this.focus == focus) return;
        this.focus = focus;
        gameObject.transform.position = focus.transform.position + offset;
    }

    private float GetBouncePosition(float time)
    {
        return Mathf.Abs(Mathf.Sin(time));
    }
}
