using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphinxReal : CharacterDialogue, Entity
{
    public List<string> itemsToCollect;
    [SerializeField] private List<string> itemsBeaHasCollected;
    public string nextScene;
    public GameObject exit;
    public static int lastInteractIndex;

    new public void Interact(Entity entity)
    {
        timesInteracted = lastInteractIndex;
        if (timesInteracted >= lines.Count - 2)
        {
            itemsToCollect.Sort();
            Inventory.inventory.Sort();
            if (IsEqual(Inventory.inventory,itemsToCollect))
            {
                Debug.Log("Yes");
                timesInteracted = lines.Count - 2;
                base.Interact(entity);
                exit.SetActive(false);
                InstantiateLoadingScreen.Instance.LoadNewScene(nextScene);
                timesInteracted = lines.Count - 2;
            }
            else { 
                Debug.Log("No");
                timesInteracted = lines.Count - 1;
                base.Interact(entity);
                timesInteracted = lines.Count - 2;
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

    private bool IsEqual(List<string> list1, List<string> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }
        return true;
    }
}