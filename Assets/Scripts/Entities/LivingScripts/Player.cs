using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living, Entity
{
    // Start is called before the first frame update
    private FocusArrowScript arrowScript;

    void Awake()
    {
        arrowScript =  gameObject.AddComponent<FocusArrowScript>();
        entityMaxSpeed = 4.2f;
        K_friction = 20f; // should be roufly 5 times the entity max Speed to not get an "ice floor" effect
    }
    new void Start()
    {
        if (debug) print("Starting at Player");

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
        Move(JoystickInput.worldOrientedJoystickDirection * speed * Time.deltaTime);
        
        arrowScript.SetFocus(brain.GetClosestEntityAsGO());
    }


    new public void Interact(Entity entity)
    { 
        base.Interact(this);
    }
}
