using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{

    SetDialogueBoxText dialogue;

    public string[] futureDialogue;
    int dialogueLine = 0;
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
        //dialogue.lines[0] = futureDialogue[dialogueLine];
        if (dialogue.lines.Length > 0)
        {
            print("interacting");
            dialogue.Talk();
            if (futureDialogue.Length == 0)
            {
                return;
            }
            if (futureDialogue.Length > 0)
            {
                dialogue.lines = new string[futureDialogue.Length];
            }
        }
        

        //dialogueLine++;
    }
}
