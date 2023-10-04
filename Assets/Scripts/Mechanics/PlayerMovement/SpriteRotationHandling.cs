using UnityEngine;
using System.Collections;

public class SpriteRotationHandling : MonoBehaviour
{
    private Animator animator;
    public float accelerationConstant;
    private Vector3 acceleration;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        acceleration = JoystickInput.joystickDirection;
        print(acceleration);
        animator.SetFloat("accelerationX", acceleration.x * accelerationConstant);
        animator.SetFloat("accelerationZ", acceleration.y * accelerationConstant);
    }
}
