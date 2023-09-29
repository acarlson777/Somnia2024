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
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position + offset, Time.deltaTime * convergeConstant);
    }
}
