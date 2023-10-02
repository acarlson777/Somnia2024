using UnityEngine;
using System.Collections;

public class Brain
{
    // The Entities should be responsible for sending the data to the brain.
    public SphereCollider SphereOfInteraction;
    public ArrayList EntitiesSeen;
    //Should return a (x,y) within a unit circle which can be used by the Living Entities to accelerate
    public void Update()
    {

    }

    public Vector2 GetDirectionVelocity()
    {
        return Vector2.zero;
    }
    // Should be called every time another entity wants to talk to this ones. Should be passed through entity
    public void Interact(EntityBase entity)
    {

    }
}
    