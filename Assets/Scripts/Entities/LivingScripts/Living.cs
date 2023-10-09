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
    public Brain brain = new Brain();

    public int health;
    public float speed = 1.0f;

    new protected void Start()
    {
        Initialize();
        brain.SphereOfInteraction = interactCollider;

    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update(); // Update normal entity stuff like physics and other stuff???

        // update things that are specific to living entities like brain
        brain.Update();
        print(brain.getCollidingCount());

    }
   
}
