using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    public DungeonBlock block1, block2, block3;
    public DungeonPressurePlate plate1, plate2, plate3;
    public DungeonGate gate;


    // Update is called once per frame
    void Update()
    {

      // Check if all blocks are on their pressure plates
      if (plate1.isOccupied && plate2.isOccupied && plate3.isOccupied)
      {
          // Open the gate if all conditions are met
          gate.OpenGate();
      }
      else
      {
          // Close the gate if any block is not on its pressure plate
          gate.CloseGate();
      }

    }
}
