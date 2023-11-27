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
        entityMaxSpeed = 3.5f;
        K_friction = 8f;
    }
    new void Start()
    {
        print("Starting at Player");

        base.Start();
        print(brain);
        
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
