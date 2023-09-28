using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float convergeConstant;
    public Vector3 offset;
    public GameObject objectToFollow;


    void Start()
    {
        
    }

    
    void Update()
    {
        float z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position + offset, objectToFollow.transform.position, Time.deltaTime * convergeConstant);
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
