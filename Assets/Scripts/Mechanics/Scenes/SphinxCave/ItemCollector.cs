using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private static HashSet<string> collectedItems = new HashSet<string>();

    public void CollectItem(string itemName)
    {
        collectedItems.Add(itemName);
    }

    public HashSet<string> GetCollectedItems() {
        return collectedItems;
    }

    public void EmptyCollectedItems()
    {
        collectedItems.Clear();
    }

    public void Update()
    {
        // Debug.Log(Sphinx.timesInteracted);
    }
}
