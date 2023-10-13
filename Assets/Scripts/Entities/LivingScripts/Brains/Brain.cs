﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Brain
{
    // The Entities should be responsible for sending the data to the brain.
    public SphereCollider SphereOfInteraction;
    public ArrayList EntitiesSeen = new ArrayList();
    private GameObject EntityFocus = null;
    //Should return a (x,y) within a unit circle which can be used by the Living Entities to accelerate
    private int CollidingCount = 0;


    public int getCollidingCount()
    {
        return CollidingCount;
    }
    public Vector3 SphereCenter()
    {
        return SphereOfInteraction.transform.position;
    }
    


    public void Update()
    {
         List<Collider> touching = new List<Collider>();
        //Get a list of entities that the brain/entity can see
        Collider[] Colliding = Physics.OverlapSphere(SphereCenter(), SphereOfInteraction.radius);
        // Cu ll all the other spheres of interactions
        foreach (Collider collider in Colliding)
        {
            if (isEntity(collider)) { touching.Add(collider); }
        }
        CollidingCount = touching.Count - 1;
        if (touching.Count == 0)
        {
            throw new Exception("No entities were detected... which is pretty bad, check if entities are tagged as \"entity\" ");
        }
        else if (touching.Count == 1)
        {
            // If we are only detecting ourselves and our spherecollider
            EntityFocus = null;
        }
        else
        {
            Array.Sort<Collider>(touching.ToArray(),CompareDistances);
           
            // Iterate over the list of overlapped entities and get the closest one
            EntityFocus = ((BoxCollider)touching[1]).gameObject;
        }
    }
    // Should be called every frame to accelerate the entity
    public Vector2 GetDirectionAcceleration()
    {
        return Vector2.zero;
    }
    // Should be called every time another entity wants to talk to this ones. Should be passed through entity
    public void Interact(EntityBase entity) // get interacted with by the entity that gets passed in 
    {
        
    }
    public Entity GetClosestEntity()
    {
        if (EntityFocus == null) { return null; }
        return EntityFocus.GetComponent<Entity>();
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
    private bool id_eq(System.Object a, System.Object b)
    {
        return ReferenceEquals(a, b);
    }
    Int32 CompareDistances(Collider x, Collider y)
    {
        return Mathf.RoundToInt(Distance(x.gameObject.transform.position, SphereOfInteraction.center) - Distance(y.gameObject.transform.position, SphereOfInteraction.center));
    }

}
    