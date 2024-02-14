using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sphinx : InteractableObject, Entity
{
    public List<string> itemsToCollectList;
    private HashSet<string> itemsToCollect;
    public SphinxDoor sphinxDoor;
    public static int count = 0; //Remember to reset Sphinx.count upon entering the orig town center (not the riddle minigame towncenter)
    public List<DialogueLines> lines;

    new private void Start()
    {
        base.Start();
        itemsToCollect = new HashSet<string>(itemsToCollectList);
    }

    new public void Interact(Entity other)
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
                if (itemCollector.GetCollectedItems().SetEquals(itemsToCollect)) //Sort both lists prior to checking equality
                {
                    //sphinxDoor.OpenDoor();
                    DialogueManager.PopDialogue(new string[] {"success"});
                    InstantiateLoadingScreen.Instance.LoadNewScene("Main Menu");
                    PlayerPrefs.SetString("Last Scene", "Bea's Room");
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
