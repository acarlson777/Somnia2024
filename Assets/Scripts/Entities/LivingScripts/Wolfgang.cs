using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfgang : Living, Entity
{
    // references to all of the island selectors
    public IslandSelector[] selectors;
    public bool firstTime = true;
    // Start is called before the first frame update
    public void Awake()

    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        selectors = new IslandSelector[others.Length];
        for (int i = 0; i < others.Length; i++) 
        {
            selectors[i] = others[i].GetComponent<IslandSelector>();
        }
    }
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    private string getSelectedName()
    {
        for (int i = 0; i < selectors.Length; i++)
        {
            if (selectors[i].isOn)
            {
                return selectors[i].IslandName;
            }
        }
        return null;
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (firstTime)
            {
                firstTime = false;
                string island = getSelectedName();
                if (island == null)
                    DialogueManager.PopDialogue(new string[] { "Hello", "My name is Wolfgang (im a not a wolf in a gang)", "You should probably interact with the emmas" });
                else
                    DialogueManager.PopDialogue(new string[] { "Hello", "My name is Wolfgang (im a not a wolf in a gang)", "You seem to want to go to " + island, "please proceed onto the train!" });
            } 
            else
            {
                string island = getSelectedName();
                if (island == null)
                    DialogueManager.PopDialogue(new string[] { "You should probably interact with the emmas" });
                else
                    DialogueManager.PopDialogue(new string[] { "Destination: " + island, "Please board the train...", "OR ELSE!!!! >;)" });
            }
        }
    }
}
