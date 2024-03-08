using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField]
    public bool isOccupied = false; // To track whether a block with correct ID is on the pressure plate
    public PushBlock correctBlock;
    public Material glowOff;
    public Material glowOn;


    void OnTriggerEnter(Collider other){

      PushBlock pushBlock = other.GetComponent<PushBlock>();

        if (pushBlock != null && pushBlock == correctBlock){
            isOccupied = true;
            gameObject.GetComponent<Renderer>().material = glowOn;
            pushBlock.startGlow();
        }
    }

    void OnTriggerExit(Collider other){
        PushBlock pushBlock = other.GetComponent<PushBlock>();

        if (pushBlock != null && pushBlock == correctBlock){
            isOccupied = false;
            gameObject.GetComponent<Renderer>().material = glowOff;
            pushBlock.stopGlow();

        }
    }

}
