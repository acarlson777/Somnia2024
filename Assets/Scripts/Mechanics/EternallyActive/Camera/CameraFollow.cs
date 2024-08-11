using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // CameraFollow converges on the player's position with an offset according to a constant
    public float convergeConstant;
    private Vector3 offset;
    public Vector3 dialogueOffset;
    public Vector3 nonDialogueOffset;
    public GameObject objectToFollow;
    private Transform objectTransform;
    private Vector3 target;
    private float yDistanceThreshold;

    public float timeToCombine;
    private float timeLeft = 0;


    private GameObject characterDialogueBox;

    //Make camera move down when dialogue is triggered when CharacterDialogueBox gameobjectr is found by name


    private void Start()
    {
        offset = nonDialogueOffset;
        transform.position = objectToFollow.transform.position + offset;
        objectTransform = objectToFollow.transform;
    }

    void FixedUpdate()
    {
        // Update Target Vec3
        characterDialogueBox = GameObject.Find("CharacterDialogueBox");
        if (characterDialogueBox != null)
        {
            offset = dialogueOffset;
            convergeConstant = 4.5f;

        } else
        {
            offset = nonDialogueOffset;
            convergeConstant = 4.5f;
        }


        target.x = objectTransform.position.x;
        target.z = objectTransform.position.z;
        //only update y value if its within a certain area
        float yDist = objectTransform.position.y - target.y;
        float yDistAbs = Math.Abs(yDist);
        float toMove= Mathf.Max(yDistAbs - yDistanceThreshold, 0);
        if (!Mathf.Approximately(toMove, 0.0f))
        {
            target.y += toMove * Mathf.Sign(yDist);
        } else
        {
            // we shouldn't move but if enought time has elapsed then why not?
            if (!Mathf.Approximately(yDist,0.0f))
            {

                timeLeft -= Time.fixedDeltaTime;
                if (timeLeft < 0)
                {
                    target.y = objectTransform.position.y;
                }
            }
            else
            {
                timeLeft = timeToCombine;
            }
        }


        // Update Camera Position to move towards the Target


        Vector3 distance = target - transform.position + offset;
        transform.position += distance * (Time.fixedDeltaTime * convergeConstant);


            
    }
    
}
