using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static List<string> inventory;

    public static bool addItem(string item)
    {
        if (inventory.Contains(item))
        {
            return false;
        }

        inventory.Add(item);
        return true;
    }

    public static void emptyInventory()
    {
        inventory = new List<string>();
    }

    private void Update()
    {
        //
    }
}
