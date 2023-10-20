using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living, Entity
{
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    new protected void Update()
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
    new public void Interact(Entity entity)
    { 
        base.Interact(this);
    }
}
