using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Brain
{
    // The Entities should be responsible for sending the data to the brain.
    private SphereCollider SphereOfInteraction;
    public ArrayList EntitiesSeen = new ArrayList();
    private GameObject EntityFocus = null;
    private Entity entity = null;
    //Should return a (x,y) within a unit circle which can be used by the Living Entities to accelerate
    private int CollidingCount = 0;

    public Brain(Entity entity, SphereCollider interactCollider)
    {
        this.entity = entity;
        this.SphereOfInteraction = interactCollider;

    }


    public int getCollidingCount()
    {
        return CollidingCount;
    }
    public Vector3 SphereCenter()
    {
        return SphereOfInteraction.transform.position;
    }
    

    public void SetSeen(List<GameObject> seen)
    {
        GameObject[] seenArr = seen.ToArray();
        Array.Sort(seenArr, CompareDistances);
        EntityFocus = seenArr.Length == 0 ? null : seenArr[0];
    }

    /// <summary>
    ///     Should be called every time another entity wants to talk to this ones. Should be passed through entity
    /// </summary>
    /// <returns>Vector2</returns>
    public Vector2 GetDirectionAcceleration()
    {
        return Vector2.zero;
    }

    public void Interact(EntityBase entity) // get interacted with by the entity that gets passed in 
    {
        
    }
    /// <summary>
    /// Returns closest Entity as the Entity Interface
    /// </summary>
    public Entity GetClosestEntity()
    {
        if (EntityFocus == null) { return null; }
        return EntityFocus.GetComponent<Entity>();
    }

    /// <returns>Closest GameObject of an Entity</returns>
    public GameObject GetClosestEntityAsGO()
    {
        return EntityFocus;
    }



    // Helper Functions
    private float Distance(Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }

    private bool isEntity(Collider col)
    {
        return col is BoxCollider && col.gameObject.tag == "entity";
    }


    Int32 CompareDistances(GameObject x, GameObject y)
    {
        return Mathf.RoundToInt(Distance(x.transform.position, SphereOfInteraction.center) - Distance(y.transform.position, SphereOfInteraction.center));
    }

}
    