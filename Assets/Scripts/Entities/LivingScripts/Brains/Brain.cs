using UnityEngine;
using System.Collections;

public class Brain
{
    // The Entities should be responsible for sending the data to the brain.
    public SphereCollider SphereOfInteraction;
    public ArrayList EntitiesSeen = new ArrayList();
    private GameObject EntityFocus = null;
    //Should return a (x,y) within a unit circle which can be used by the Living Entities to accelerate


    public void Update()
    {
        //Get a list of entities that the brain/entity can see
        Collider[] Colliding = Physics.OverlapSphere(SphereOfInteraction.center, SphereOfInteraction.radius);
        if (Colliding.Length == 0)
        {
            throw new System.Exception("No entities were detected... which is pretty bad");
        }
        else if (Colliding.Length == 1)
        {
            EntityFocus = null;
        }
        else
        {
            // Iterate over the list of overlapped entities and get the closest one
            GameObject us = Colliding[0].gameObject;    
            float shortestDistance = float.MaxValue;
            for (int i = 0; i < Colliding.Length;i++)
            {
                if (!isEntity(Colliding[i].gameObject)) continue;
                float dist = Distance(Colliding[i].gameObject.transform.position, SphereOfInteraction.center);

                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    us = Colliding[i].gameObject;
                }
            }

            for (int i = 0; i < Colliding.Length; i++)
            {
                if (!isEntity(Colliding[i].gameObject)) continue;
                float dist = Distance(Colliding[i].gameObject.transform.position, SphereOfInteraction.center);
                if (Colliding[i].gameObject == us) continue;
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    EntityFocus = Colliding[i].gameObject;
                }
            }
        }
    }

    public Vector2 GetDirectionVelocity()
    {
        return Vector2.zero;
    }
    // Should be called every time another entity wants to talk to this ones. Should be passed through entity
    public void Interact(EntityBase entity) // get interacted with by the entity that gets passed in 
    {
        
    }
    public Entity GetClosestEntity()
    {
        return EntityFocus.GetComponent<Entity>();
    }
    // Helper Functions

    private float Distance(Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }

    private bool isEntity(GameObject obj)
    {
        return obj.tag == "entity";
        
        
    }

}
    