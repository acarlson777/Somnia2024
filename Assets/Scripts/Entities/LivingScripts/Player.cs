using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living
{
    // Start is called before the first frame update
    new void Start()
    {
        brain.SphereOfInteraction = interactCollider;
        base.Start();
        
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (brain.GetClosestEntity() != null)
            {
                brain.GetClosestEntity().Interact(this);
            }
            else
            {
                print("No entity to interact with!");   
            }
        }   
    }
}
