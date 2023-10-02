using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.I))
        {

        }   
    }
}
