using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public enum State
    {
        STOPPED,
        WALKING,
        TARGET_REACHED,
        STUCK,
    }
    [SerializeField] private float TargetDistance = 1;
    [SerializeField] private float SightDistance = 999;
    [SerializeField] private float Speed = 1;
    [SerializeField] private GameObject Mark;
    [SerializeField] private State _state = State.STOPPED;
    [SerializeField] private int layerNum;
    [SerializeField] private Animator anim;
    [SerializeField] private float velocityConstant;

    public State state => _state;


    //Targeting System Vars
    private const float speedThreshold = 0.25f;
    private Vector3 lastSeen;
    private float lastDistanceToMark;
    private bool canSeeMark;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb ==null)
        {
            Debug.Log("Follow Target Script Gamobject does not have a Rigidbody, please Attach one!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        canSeeMark = CanSeeMark();
        if (canSeeMark)
        {
            lastSeen = Mark.transform.position;
            lastSeen.y = transform.position.y;
            lastDistanceToMark = DistanceToMark();
        }
        //print("Can See Mark:" + canSeeMark);
        bool shouldMoveToLastSeen = (canSeeMark && lastDistanceToMark > TargetDistance) || (!canSeeMark);
        print("Should Move To: " + shouldMoveToLastSeen);
        if (shouldMoveToLastSeen)
        {
            if (canSeeMark)
                _state = State.WALKING;

            else if (rb.velocity.magnitude < speedThreshold)
            {
                _state = State.STUCK;
            }
            MoveToLastSeen();
        } else
        {
            Stop();
            if (DistanceToMark() < TargetDistance)
                _state = State.TARGET_REACHED;
            else
                _state = State.STOPPED;


        }

        if (anim != null)
        {
            anim.SetFloat("accelerationX", rb.velocity.x * velocityConstant);
            anim.SetFloat("accelerationZ", rb.velocity.z * velocityConstant);
        }

    }

    float DistanceToMark()
    {
        Vector3 markT = Mark.transform.position;
        markT.y = transform.position.y;
        return (markT- transform.position).magnitude;
    }
    private Vector3[] getPositionsAroundMark()
    {
        return new Vector3[] { Mark.transform.position, Mark.transform.position + Vector3.left/2, Mark.transform.position + Vector3.right /2, Mark.transform.position + Vector3.forward/2, Mark.transform.position + Vector3.back/2};
    }

    bool CanSeeMark()
    {
        if (DistanceToMark() > SightDistance) return false;
        foreach (Vector3 p in getPositionsAroundMark())
        {

            if (Physics.Linecast(transform.position, p, 1 << layerNum))
            {
                 return false;

            }
            else
            {

            }
        }
        return true;
    }
    private void OnDrawGizmos()
    {
        foreach (Vector3 p in getPositionsAroundMark())

            Gizmos.DrawLine(transform.position, p);
   

    }

    void MoveToLastSeen()
    {
   
        var distanceToLastSeen = (lastSeen - transform.position).magnitude;
        var d = distanceToLastSeen - (canSeeMark? TargetDistance : 0)+1;

        float multiplier = Mathf.Max(d, 0); ;

        rb.velocity = ((lastSeen - transform.position).normalized * Speed * multiplier);
  
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
    }

}