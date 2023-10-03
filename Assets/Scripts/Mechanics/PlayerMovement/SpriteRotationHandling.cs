using UnityEngine;
using System.Collections;

public class SpriteRotationHandling : MonoBehaviour
{
    private Animator animator;
    public Rigidbody parentRb;
    public float accelerationConstant;


    private Vector3 acceleration;
    private Vector3 lastVelocity = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        acceleration = (parentRb.velocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = parentRb.velocity;
        animator.SetFloat("accelerationX", acceleration.x * accelerationConstant);
        animator.SetFloat("accelerationZ", acceleration.z * accelerationConstant);
    }
}
