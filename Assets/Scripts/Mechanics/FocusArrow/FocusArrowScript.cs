using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusArrowScript : MonoBehaviour
{
    // This is the script to be attached as a component to a physical arrow that wil bounce up and down on top of focused entities
    private GameObject focus;
    public Vector3 offset = new Vector3(0,1.5f,0);
    private bool active = false;
    private GameObject arrow; 

    // Helper varibles .. Not needed but boost performance a bit
    // no helper variables
    private void Start()
    {
        arrow = Instantiate(Resources.Load("FocusArrow") as GameObject); // get the Dialogue Prefab in the Resources Folder named "DialogueBox"
        arrow.SetActive(false);
        //meshRenderer = arrow.GetComponent<MeshRenderer>();

    }


    void Update()
    {
        if (!active) return;
        arrow.transform.position = focus.transform.position + offset + new Vector3(0,GetBouncePosition(Time.time),0);
    }
    public void SetFocus(GameObject focus)
    {
        if ((focus != null) != active)
        {
            if (active)
            {
                // set mesherender active to true
                arrow.SetActive(false);
            }
            else
            {
                // set it to false
                arrow.SetActive(true);
            }
        }
        active = focus != null;
        if (!active) return;
        if (this.focus == focus) return;
        this.focus = focus;
        arrow.transform.position = focus.transform.position + offset;
    }

    private float GetBouncePosition(float time)
    {
        float value1 = Mathf.Sin(time * 1.22f);



        return value1 *value1 * 0.7f;
    }
}
