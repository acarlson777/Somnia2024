﻿using UnityEngine;
using System.Collections;

public class SphinxDoor : MonoBehaviour
{
    public bool doorOpen = false;

    private Vector3 startPos;
    public float gateSpeed = 1.0f;
    public float gateEndDistance = 3.0f;
    private Vector3 endPos;

    public void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + gateEndDistance, startPos.z);
    }

    public void OpenDoor()
    {
        doorOpen = true;
    }

    void Update()
    {
        if (doorOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * gateSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * gateSpeed);
        }

    }
}