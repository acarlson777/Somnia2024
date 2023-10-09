using UnityEngine;
using System.Collections;

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
        ArrayList seen = new ArrayList();
        //Get a list of entities that the brain/entity can see
        Collider[] Colliding = Physics.OverlapSphere(SphereCenter(), SphereOfInteraction.radius);
        CollidingCount = 0;
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
            for (int i = 0; i < seen.Capacity;i++)
            {
                if (!isEntity(Colliding[i])) continue;
                float dist = Distance(Colliding[i].gameObject.transform.position, SphereOfInteraction.center);

                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    us = Colliding[i].gameObject;
                }
            }

            for (int i = 0; i < Colliding.Length; i++)
            {
                if (!isEntity(Colliding[i])) continue;
                CollidingCount++;
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
        return col is SphereCollider && col.gameObject.tag == "entity";
    }
    private bool id_eq(Object a, Object b)
    {
        return ReferenceEquals(a, b);
    }

}
    