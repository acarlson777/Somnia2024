using UnityEngine;
using System.Collections;

public class ItemNPC : CharacterDialogue
{
    public string item;

    new private void Interact(Entity entity)
    {
        if (timesInteracted >= lines.Count - 3)
        {
            if (Inventory.addItem(item))
            {
                timesInteracted = lines.Count - 2;
            }
            timesInteracted = lines.Count - 1;
            return;
        }
        base.Interact(entity);
        timesInteracted = lines.Count - 3;
    }
}