using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sphinx : InteractableObject, Entity
{
    public List<string> itemsToCollect;
    public SphinxDoor sphinxDoor;

    public void Interact(Entity other)
    {
        if (other is Player)
        {
            ItemCollector itemCollector = other.gameObject.GetComponent<ItemCollector>();
            if (itemCollector.GetCollectedItems().Equals(itemsToCollect))
            {
                sphinxDoor.OpenDoor();
            }
        }
    }

    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}
