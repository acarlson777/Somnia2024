using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public NewPressurePlate plate1, plate2, plate3;
    public DungeonGate gate;
    public bool doPreventGateFromClosing = false;

    // Update is called once per frame
    void Update()
    {

      // Check if all blocks are on their pressure plates
      if (plate1.isPressed && plate2.isPressed && plate3.isPressed) {
          // Open the gate if all conditions are met
          gate.OpenGate();
          doPreventGateFromClosing = true;

      } else if (!doPreventGateFromClosing){
          // Close the gate if any block is not on its pressure plate
          gate.CloseGate();
      }

    }
}
