using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfgang : Living, Entity
{
    // references to all of the island selectors
    public IslandSelector[] selectors;
    public bool firstTime = true;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (firstTime)
            {
                DialogueManager.PopDialogue(new string[] { "Hello" , "My name is Wolfgang (im a not a wolf in a gang)" });
                firstTime = false;
            }

        }
    }
}
