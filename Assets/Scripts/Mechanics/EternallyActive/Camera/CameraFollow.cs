using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // CameraFollow converges on the player's position with an offset according to a constant
    public float convergeConstant;
    public Vector3 offset;
    public GameObject objectToFollow;
    private void Start()
    {
        transform.position = objectToFollow.transform.position + offset;
    }

    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position + offset, Time.deltaTime * convergeConstant);

        Vector3 distance = objectToFollow.transform.position - transform.position + offset;
        distance.y = 0;
        transform.position = new Vector3(transform.position.x, offset.y, transform.position.z);
        transform.position += distance * Time.deltaTime * convergeConstant;

            
    }
    
}
