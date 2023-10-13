using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private Vector3 input;
    private float speed = 5f;
    Vector3 movement;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void PlayerInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void Move()
    {
        movement = input.normalized;
        movement = Quaternion.Euler(0, 45, 0) * movement;
        movement = movement.normalized;

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                transform.Translate(movement * 9 * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

}
