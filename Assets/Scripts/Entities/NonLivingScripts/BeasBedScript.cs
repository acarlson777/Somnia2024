using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeasBedScript : InteractableObject, Entity
{
    public static bool readyForDreaming = false;
    new void Start()
    {
        base.Start();

    }

    new void Update()   
    {
        base.Update();
    }
    new void Interact(Entity other)
    {
        if (other is Player)
        {
            if (readyForDreaming)
            {
                // add the screen transition here
                // move to the next scene
            }
                
        }
    }
}
