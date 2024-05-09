using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphinxReal : CharacterDialogue
{
    public List<string> itemsToCollect;
    [SerializeField] private List<string> itemsBeaHasCollected;
    public string nextScene;
    public GameObject exit;
    public static int lastInteractIndex;

    new public void Interact(Entity entity)
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
                timesInteracted = lines.Count - 3;
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

    new private void Update()
    {
        base.Update();
        itemsBeaHasCollected = Inventory.inventory;
    }
}