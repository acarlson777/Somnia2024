using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private static List<string> collectedItems;

    public void CollectItem(string itemName)
    {
        collectedItems.Add(itemName);
    }

    public List<string> GetCollectedItems() { 
        return collectedItems;
    }
}
