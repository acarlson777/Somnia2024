using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    [SerializeField]
    private int correctBlockID; // ID of the correct block for this pressure plate

    public bool isOccupied = false; // To track whether a block with correct ID is on the pressure plate

    void OnTriggerEnter(Collider other)
    {
        DungeonBlock block = other.GetComponent<DungeonBlock>();

        if (block != null && block.BlockID == correctBlockID)
        {
            isOccupied = true;
        }

        print("TRIGET ENTER");
    }

    void OnTriggerExit(Collider other)
    {

      print("TRIGET EXIT");
        DungeonBlock block = other.GetComponent<DungeonBlock>();

        if (block != null && block.BlockID == correctBlockID)
        {
            isOccupied = false;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
