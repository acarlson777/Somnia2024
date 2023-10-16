using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{
    string[] diaglogues;
    int timesInteracted = 0;
    SetDialogueBoxText dialogue;

    public string[] futureDialogue;
    bool interactedWith = false;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dialogue = gameObject.GetComponent<SetDialogueBoxText>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity entity) // Interact is a method which can be overridden but does not need to call the base version
    {
        //PopDialogue(dialogues[timesInteracted]);
        if (interactedWith == false)
        {
            print("interacting");
            dialogue.Talk();
            if (futureDialogue.Length > 0)
            {
                interactedWith = true;
                timesInteracted++;
            }
            else
            {
                return;
            }
        }
        if (timesInteracted == 1)
        {
            dialogue.lines = futureDialogue;
            dialogue.Talk();
            timesInteracted++;
        }
        if (timesInteracted == 2)
        {
            dialogue.lines = new string[1];
            dialogue.lines[0] = "Hello";
            dialogue.Talk();
        }
    }
}
