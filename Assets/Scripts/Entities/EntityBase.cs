using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
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
    protected void Initialize()
    {
        rb = GetComponent<Rigidbody>();

    }


    public void Start()
    {
        Initialize();
    }
    // Update is called once per frame
    protected void Update()
    {
        if (vel.magnitude > entityMaxSpeed)
        {
            vel *= entityMaxSpeed / vel.magnitude; // Set the magnitude to maxSpeed
        }
        rb.velocity = vel;
    }
    protected void Move(Vector3 accel)
    {
        vel += accel;
    }
    public string GetName()
    {
        return GetType().Name;
    }

    protected void PrintName()
    {
        print(GetType().Name);
    }
    public void Interact(EntityBase entity)
    {
        print(entity.GetName());
    }
}
