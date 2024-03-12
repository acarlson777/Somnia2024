using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is meant for when you have a rotatinng parent and you want the child to not spin
/// </summary>
public class AntiSpin : MonoBehaviour
{
    private Quaternion startRot;
    // Start is called before
    // the first frame update
    private void Awake()
    {
        startRot = transform.rotation;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = startRot;
    }
}
