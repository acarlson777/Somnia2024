using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphinxReal : CharacterDialogue
{
    public List<string> itemsToCollect;
    public string nextScene;
    public GameObject exit;
    public static int lastInteractIndex;

    new private void Interact(Entity entity)
    {
        timesInteracted = lastInteractIndex;
        if (timesInteracted == lines.Count - 3)
        {
            itemsToCollect.Sort();
            Inventory.inventory.Sort();
            if (itemsToCollect.Equals(Inventory.inventory))
            {
                timesInteracted = lines.Count - 2;
                base.Interact(entity);
                exit.SetActive(false);
                InstantiateLoadingScreen.Instance.LoadNewScene(nextScene);
            } else
            {
                timesInteracted = lines.Count - 1;
                base.Interact(entity);
                timesInteracted = lines.Count - 3;
            }
            lastInteractIndex = timesInteracted;
            return;
        }
        base.Interact(entity);
        lastInteractIndex = timesInteracted;
    }
}