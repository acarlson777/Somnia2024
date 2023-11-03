using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Entity 
{
    void Start();
    void Update();
    void Move(Vector3 accel);
    string GetName();
    void PrintName();
    void Interact(Entity entity);
}

public class EntityBase : MonoBehaviour,Entity
{
    // Each entity should be a:
    //    - World Collidable(aka. collider
    //    - Interactable via Interact button
    //    - Questions: how big should the interact collider be????
    private Rigidbody rb;
    public BoxCollider entityCollider;
    public SphereCollider interactCollider;
    public float BoxColliderThickness;

    private Vector3 accel;
    private Vector3 vel;
    public float entityMaxSpeed = 2.1f;
    protected float K_friction = 5.0f; // Coefficient of Friction
    public void Initialize()
    {
        rb = GetComponent<Rigidbody>();

    }


    public void Start()
    {
        tag = "entity"; 
        Initialize();
    }
    // Update is called once per frame
    public void Update()
    {
        vel += accel;
        if (vel.magnitude > entityMaxSpeed) // Can be optimized
        {
            vel *= entityMaxSpeed / vel.magnitude; // Set the magnitude to maxSpeed
        }
        // Overwrite the y axis since that should be taken care of by unity itself
        vel.y = 0;
        // Apply Horizontal Friction
        if (vel.magnitude < K_friction * Time.deltaTime)
        {
            vel.x = 0;
            vel.y = 0;
            vel.z = 0;
        }
        else
        {
            Vector3 friction = vel.normalized * -K_friction * Time.deltaTime;
            friction.y = 0;
            vel += friction;
        }
        vel.y = rb.velocity.y;
        rb.velocity = vel;


    }

    public void Move(Vector3 accel)
    {
        vel += accel;
    }

    public string GetName()
    {
        return GetType().Name;
    }

    public void PrintName()
    {
        print(GetType().Name);
    }

    public void Interact(Entity entity)
    {
        print(entity.GetName() + " interacted with me... a " + GetName());
    }

}
