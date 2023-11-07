using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempScript : MonoBehaviour
{
    //Translates the player's position (not by force) using the joystick world orientated value times a movementDirection constant
    private Rigidbody rb;
    public float movementDirection = 5;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //rb.AddForce(JoystickInput.joystickDirection);

        transform.Translate(JoystickInput.worldOrientedJoystickDirection * movementDirection * Time.deltaTime);
    }
}
    