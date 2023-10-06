using UnityEngine;
using System.Collections;

public class SpriteRotationHandling : MonoBehaviour
{
    //Handles the character's animation by setting the animation controllers acceleration values (x and z) from the Joystick's direction (x and y)
    // - Goes from Joystick x and y to animation controller x and z | (x->x, y->z)

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
