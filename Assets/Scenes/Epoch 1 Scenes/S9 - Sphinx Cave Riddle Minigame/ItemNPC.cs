using UnityEngine;
using System.Collections;

public class ItemNPC : CharacterDialogue, Entity
{
    public string item;

    new public void Interact(Entity entity)
    {
        Debug.Log("NPC DIALOGUE");
        Debug.Log(lines.Count);
        if (timesInteracted >= lines.Count - 2)
        {
            Debug.Log(Inventory.inventory);
            if (Inventory.addItem(item))
            {
                timesInteracted = lines.Count - 2;
            } else
            {
                timesInteracted = lines.Count - 1;
            }
            base.Interact(entity);
            timesInteracted = lines.Count - 2;
            return;
        }
        base.Interact(entity);
    }
}