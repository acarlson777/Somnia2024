using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : EntityBase
{
    // Living Entities should have the following attributes:
    // - Hitpoints
    // - Speed
    // - Brain
    // Brain wil manage:
    // Entity behavior
    public Brain brain;

    public int health;
    public float speed = 1.0f;

    new public void Start()
    {
        print("Starting from Living");


        brain = new Brain(this,interactCollider);
        print("Made Brain");
        Initialize();


    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update(); // Update normal entity stuff like physics and other stuff???

        // update things that are specific to living entities like brain
        brain.Update();

    }
    new public void Interact(Entity other)
    {
        print(other.GetName() + " interacted with me... a " + GetName());
    }

}
