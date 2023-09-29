using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
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


    protected void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    // Update is called once per frame
    void Update()
    {
        if (vel.magnitude > entityMaxSpeed)
        {
            vel *= entityMaxSpeed / vel.magnitude; // Set the magnitude to maxSpeed
        }
        rb.velocity = vel;
    }
    void Move(Vector3 accel)
    {
        vel += accel;
    }
    protected void PrintName()
    {
        print(GetType().Name);
    }
}
