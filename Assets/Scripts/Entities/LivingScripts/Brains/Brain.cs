using UnityEngine;
using System.Collections;

public class Brain
{
    // The Entities should be responsible for sending the data to the brain.
    public ArrayList EntitiesSeen;
    //Should return a (x,y) within a unit circle which can be used by the Living Entities to accelerate
    public Vector2 GetDirectionVelocity()
    {
        return Vector2.zero;
    }
    // Should be called every time another entity wants to talk to this ones. Should be passed through entity
    public Vector2 Talk(EntityBase entity)
    {
        return Vector2.zero;
    }
}
    