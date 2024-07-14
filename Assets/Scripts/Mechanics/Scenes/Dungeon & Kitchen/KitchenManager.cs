using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public PressurePlate plate1, plate2, plate3;
    public DungeonGate gate;
    public bool doPreventGateFromClosing = false;

    // Update is called once per frame
    void Update()
    {

      // Check if all blocks are on their pressure plates
      if (plate1.isOccupied && plate2.isOccupied && plate3.isOccupied) {
          // Open the gate if all conditions are met
          gate.OpenGate();
          doPreventGateFromClosing = true;

      } else if (!doPreventGateFromClosing){
          // Close the gate if any block is not on its pressure plate
          gate.CloseGate();
      }

    }
}
