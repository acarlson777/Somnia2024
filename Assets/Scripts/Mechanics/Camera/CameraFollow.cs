using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // CameraFollow converges on the player's position with an offset according to a constant
    public float convergeConstant;
    public Vector3 offset;
    public GameObject objectToFollow;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position + offset, Time.deltaTime * convergeConstant);
    }
}
