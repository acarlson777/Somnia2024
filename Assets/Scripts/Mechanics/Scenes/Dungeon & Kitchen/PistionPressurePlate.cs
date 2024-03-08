using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistionPressurePlate : MonoBehaviour
{

    [SerializeField]
    public Pistion pistion;
    public Material glowOff;
    public Material glowOn;


    void OnTriggerEnter(Collider collider){

      PushBlock pb = collider.gameObject.GetComponent<PushBlock>();


      if(pb != null){
        print("ACTIVATE PISTON!");
        pistion.activate();
      }

        // Disable for 2s
    }

}
