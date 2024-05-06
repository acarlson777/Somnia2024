using UnityEngine;
using System.Collections;

public class EmptyInventoryAndResetSphinx : MonoBehaviour
{
    void Start()
    {
        Inventory.emptyInventory();
        SphinxReal.lastInteractIndex = 0;
    }
}
