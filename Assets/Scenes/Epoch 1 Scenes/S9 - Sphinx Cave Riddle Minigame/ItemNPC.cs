using UnityEngine;
using System.Collections;

public class ItemNPC : CharacterDialogue
{
    public string item;

    new public void Interact(Entity entity)
    {
        Debug.Log("NPC DIALOGUE");
        Debug.Log(lines.Count);
        if (timesInteracted >= lines.Count - 3)
        {
            if (Inventory.addItem(item))
            {
                timesInteracted = lines.Count - 2;
            }
            timesInteracted = lines.Count - 1;
            base.Interact(entity);
            return;
        }
        base.Interact(entity);
        timesInteracted = lines.Count - 3;
    }
}