using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPressurePlate : MonoBehaviour
{

    [SerializeField]
    public bool isOccupied = false; // To track whether a block with correct ID is on the pressure plate
    public DungeonBlock correctBlock;
    public Material glowOff;
    public Material glowOn;


    void OnTriggerEnter(Collider other){

      DungeonBlock dungeonBlock = other.GetComponent<DungeonBlock>();

        if (dungeonBlock != null && dungeonBlock == correctBlock){
            isOccupied = true;
            gameObject.GetComponent<Renderer>().material = glowOn;
            dungeonBlock.startGlow();
        }
    }

    void OnTriggerExit(Collider other){
        DungeonBlock dungeonBlock = other.GetComponent<DungeonBlock>();

        if (dungeonBlock != null && dungeonBlock == correctBlock){
            isOccupied = false;
            gameObject.GetComponent<Renderer>().material = glowOff;
            dungeonBlock.stopGlow();

        }
    }

}
