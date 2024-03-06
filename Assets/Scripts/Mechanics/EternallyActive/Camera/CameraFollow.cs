using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // CameraFollow converges on the player's position with an offset according to a constant
    public float convergeConstant;
    public Vector3 offset;
    public GameObject objectToFollow;
    public float yDistanceThreshold;
    private float lastYDist;
    private float timeFromLastYChange;
    public float pauseYChangeTime;
    private void Start()
    {
        transform.position = objectToFollow.transform.position + offset;
    }

    void FixedUpdate()
    {
        

        Vector3 distance = objectToFollow.transform.position - transform.position + offset;

        var yDist = transform.position.y - objectToFollow.transform.position.y - offset.y;
        var toMove =(Mathf.Abs(yDist) - yDistanceThreshold);
        if (toMove < 0) toMove = 0;
        toMove *= Mathf.Sign(yDist);
        distance.y = 0;

        if (Mathf.Approximately(lastYDist,yDist))
        {
            timeFromLastYChange += Time.deltaTime;
            
            if (pauseYChangeTime > 0 && timeFromLastYChange > pauseYChangeTime)
            {
                distance.y = yDist;
            }
        } else
        {
            timeFromLastYChange = 0;
        }
        
        
        transform.position = new Vector3(transform.position.x, transform.position.y - toMove, transform.position.z);
        
        transform.position += distance * (Time.deltaTime * convergeConstant);
        lastYDist = yDist;
            
    }
    
}
