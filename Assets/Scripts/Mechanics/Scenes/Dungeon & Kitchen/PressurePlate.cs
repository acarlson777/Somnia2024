using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField]
    public bool isOccupied = false; // To track whether a block with correct ID is on the pressure plate
    public Material glowOff;
    public Material glowOn;
    public PushBlock correctBlock;
    public bool lockIn;
    public bool blockSpecific;
    private bool lockedIn = false;
    public float lockInTime;


    void OnTriggerEnter(Collider other){

      PushBlock pushBlock = other.GetComponent<PushBlock>();

        if (pushBlock.name.Equals("Block") && !blockSpecific){
            isOccupied = true;
            gameObject.GetComponent<Renderer>().material = glowOn;
            if (lockIn) { StartCoroutine(LockIn()); }
            pushBlock.startGlow();
        }
        else if (pushBlock != null && pushBlock == correctBlock && blockSpecific)
        {
            isOccupied = true;
            gameObject.GetComponent<Renderer>().material = glowOn;
            if (lockIn) { StartCoroutine(LockIn()); }
            pushBlock.startGlow();
        }
    }

    void OnTriggerExit(Collider other){
        PushBlock pushBlock = other.GetComponent<PushBlock>();

        if (pushBlock != null && pushBlock.name.Equals("Block") && !blockSpecific)
        {
            isOccupied = false;
            gameObject.GetComponent<Renderer>().material = glowOff;
            pushBlock.stopGlow();

        } else if (pushBlock != null && pushBlock == correctBlock && blockSpecific)
        {
            isOccupied = false;
            gameObject.GetComponent<Renderer>().material = glowOff;
            pushBlock.stopGlow();
        }
    }
    
    IEnumerator LockIn()
    {
        print("Locking in");
        Vector3 pressurePlatePos = transform.position;
        pressurePlatePos.y += 0.5f;
        float timeTaken = 0;
        Vector3 startingPos = correctBlock.gameObject.transform.position;
        while (timeTaken < lockInTime)
        {
            correctBlock.gameObject.transform.position = Vector3.Lerp(startingPos, pressurePlatePos, timeTaken/lockInTime);
            timeTaken += Time.deltaTime;
            yield return null;
        }
        correctBlock.gameObject.transform.position = pressurePlatePos;
        correctBlock.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        correctBlock.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        lockedIn = true;
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("button", gameObject);
    }
    

    private void Update()
    {
    
        if (lockedIn)
        {
            Vector3 pressurePlatePos = transform.position;
            pressurePlatePos.y += 0.5f;
            correctBlock.gameObject.transform.position = pressurePlatePos;
        }

    }
}
