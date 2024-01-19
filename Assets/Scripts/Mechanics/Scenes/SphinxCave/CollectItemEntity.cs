using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectItemEntity : InteractableObject, Entity
{
    public string itemName;
    private bool collected = false;
    private int count = 0;
    public List<DialogueLines> lines;

    public void Interact(Entity other)
    {
        if (other is Player)
        {
            if (count >= lines.Count)
            {
                count = lines.Count - 1;
            }
            //DialogueManager.PopDialogue(lines[count].lines);

            if (!collected)
            {
                ItemCollector itemCollector = other.gameObject.GetComponent<ItemCollector>();
                itemCollector.CollectItem(itemName);
                DialogueManager.PopDialogue(new string[] { itemName + "collected!" });
                collected = true;
            } else
            {
                DialogueManager.PopDialogue(new string[] { "I have nothing more for you" });
            }

            count++;
        }
    }

    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}
