using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Z };

public class PistionPressurePlate : MonoBehaviour
{

    [SerializeField]
    public Pistion pistion;
    public Material glowOff;
    public Material glowOn;
    public float requredDistance;
    private Vector3 selfPosition;
    public PushBlock pb;
    public bool isOccupied = false;


    public Axis axis;

    private void Start(){
      selfPosition = transform.position;
      print(selfPosition);
    }

    private void Update(){

      if(isOccupied){

        float distance = 0;

        switch(axis){

          case Axis.X:
            distance = Mathf.Abs(selfPosition.x - pb.transform.position.x);
            break;

          case Axis.Z:
            distance = Mathf.Abs(selfPosition.z - pb.transform.position.z);
            break;


        }

        // print(distance);
        if(distance < requredDistance){
          pistion.activate();
        }
      }

    }


    void OnTriggerEnter(Collider collider){

      PushBlock pushBlock = collider.gameObject.GetComponent<PushBlock>();

      if(pushBlock != null){
        pb = pushBlock;
        isOccupied = true;
      }

    }

    void OnTriggerExit(Collider collider){
        PushBlock pushBlock = collider.GetComponent<PushBlock>();


        if (pushBlock != null){

            pb = null;
            isOccupied = false;
        }
    }

}
