using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sphinx : InteractableObject, Entity
{
    public List<string> itemsToCollect;
    public SphinxDoor sphinxDoor;
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
            
            
            if (count == 0)
            {
                ItemCollector itemCollector = other.gameObject.GetComponent<ItemCollector>();
                itemCollector.EmptyCollectedItems();
            }

            if (count == 2)
            {
                Debug.Log("yoooooooo");
                ItemCollector itemCollector = other.gameObject.GetComponent<ItemCollector>();
                if (itemCollector.GetCollectedItems().Equals(itemsToCollect)) //Sort both lists prior to checking equality
                {
                    sphinxDoor.OpenDoor();
                    DialogueManager.PopDialogue(new string[] {"success"});
                } else
                {
                    DialogueManager.PopDialogue(new string[] { "failure" });
                }
            } else
            {
                DialogueManager.PopDialogue(lines[count].lines);
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
