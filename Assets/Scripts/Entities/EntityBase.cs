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
    // Start is called before the first frame update
    // Each entity should be a:
    //    - World Collidable(aka. collider
    //    - Interactable via Interact button
    //    - Questions: how big should the interact collider be????
    private Rigidbody rb;
    public BoxCollider entityCollider;
    public Collider interactCollider;
    public float BoxColliderThickness;

    private Vector3 accel;
    private Vector3 vel;
    private float entityMaxSpeed = 4f;
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
        if (vel.magnitude > entityMaxSpeed)
        {
            vel *= entityMaxSpeed / vel.magnitude; // Set the magnitude to maxSpeed
        }
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
        print("Interacted with me "+entity.GetName());
    }
}
