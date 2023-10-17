using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{

    SetDialogueBoxText dialogue;

    string[] futureDialogue;
    string[][] dialogueText;
    public int timesInteracted = 0;
    int numberOfFutureDialogue;

    bool futureDialogueExists;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dialogue = gameObject.GetComponent<SetDialogueBoxText>();

        dialogueText = new string[][]
        {
            new string[] {"Hello I am a Testing NPC !!!", "THIS IS THE SECOND LINE OF TEXT"},
            new string[] {"2.1", "2.2", "2.3", "2.4"},
            new string[] {"3.1", "3.2", "3.3"}
        };

        // changes depending on npc
        numberOfFutureDialogue = 3;
        futureDialogueExists = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity entity)
    {

        timesInteracted++;
        if (timesInteracted > dialogueText.Length)
        {
            timesInteracted = dialogueText.Length;
        }
        DialogueManager.PopDialogue(dialogueText[timesInteracted]);
    }
    public void _Interact(Entity entity) // Interact is a method which can be overridden but does not need to call the base version
    {
        
        // Keep same for every npc / entity
        if (timesInteracted == numberOfFutureDialogue)
        {
            dialogue.Talk();
        }
        if (timesInteracted == 0)
         {
             print("interacting");
             dialogue.Talk();
            if (futureDialogueExists)
            {
                timesInteracted++;
            }
             return;
         }

        // change for every npc / entity
         if (timesInteracted == 1)
         {
            string [] futureDialogue = { "Hello", "whats up"};
            SetFutureDialogue(2, futureDialogue);
         }
         if (timesInteracted == 2)
         {
            string[] futureDialogue = { "How inefficient is this", "slightly better than last time", "yay!" };
            SetFutureDialogue(3, futureDialogue);
         }

         

        void SetFutureDialogue(int length, string[] dialogueLines)
        {
             dialogue.lines = new string[length];
             for (int i = 0; i < length; i++)
             {
                 dialogue.lines[i] = dialogueLines[i];
             }
             dialogue.Talk();
             timesInteracted++;
             return;

        }
        /*
        if (hasInteracted == false)
        {
            print("interacting");
            dialogue.Talk();
            if (futureDialogue.Length > 0)
            {
                hasInteracted = true;
            }
        }
        if (hasInteracted == true)
        {
            dialogue.lines = futureDialogue;
            dialogue.Talk();
        }
        */

    }
}


