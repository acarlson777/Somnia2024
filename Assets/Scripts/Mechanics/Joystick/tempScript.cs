using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float movementDirection = 5;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(JoystickInput.joystickDirection);

        transform.Translate(JoystickInput.worldOrientedJoystickDirection * movementDirection * Time.deltaTime);
    }
}
