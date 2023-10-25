using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living, Entity
{
    // Start is called before the first frame update
    public GameObject arrow; // :) this is the arrow to be displayed on top of then entity that is currently being focused on.
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
        Move(JoystickInput.worldOrientedJoystickDirection * 50.0f * Time.deltaTime);
    }
    new public void Interact(Entity entity)
    { 
        base.Interact(this);
    }
}
