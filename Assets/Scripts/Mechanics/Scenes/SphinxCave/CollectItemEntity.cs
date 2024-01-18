using UnityEngine;
using System.Collections;

public class CollectItemEntity : InteractableObject, Entity
{
    public string itemName;

    public void Interact(Entity other)
    {
        if (other is Player)
        {
            ItemCollector itemCollector = other.gameObject.GetComponent<ItemCollector>();
            itemCollector.CollectItem(itemName);
        }
    }

    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}
