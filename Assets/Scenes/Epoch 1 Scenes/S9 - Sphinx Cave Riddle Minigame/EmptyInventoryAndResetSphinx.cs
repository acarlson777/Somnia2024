using UnityEngine;
using System.Collections;

public class EmptyInventoryAndResetSphinx : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Inventory Initialized");
        Inventory.emptyInventory();
        SphinxReal.lastInteractIndex = 0;
    }
}
