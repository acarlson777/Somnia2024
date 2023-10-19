using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{
    string[] diaglogues;
    int timesInteracted = 0;
    SetDialogueBoxText dialogue;
    public List<VoiceLines> teee;
    public string[][] dialogueText = new string[][] {
        new string[] { "Hello I am a Testing NPC !!!", "THIS IS THE SECOND LINE OF TEXT" },
        new string[] {"2.1", "2.2", "2.3", "2.4"},
        new string[] { "3.1", "3.2", "3.3" }
    };
    public int timesInteracted = 0;
    int numberOfFutureDialogue;

    bool futureDialogueExists;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dialogue = gameObject.GetComponent<SetDialogueBoxText>();



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

        if (timesInteracted >= dialogueText.Length)
        {
            timesInteracted = dialogueText.Length-1;
        }
        DialogueManager.PopDialogue(teee[timesInteracted].lines);
        timesInteracted++;
    }
    public void _Interact(Entity entity) // Interact is a method which can be overridden but does not need to call the base version
    {
        
        // Keep same for every npc / entity
        if (timesInteracted == numberOfFutureDialogue)
        {
            dialogue.Talk();
        if (timesInteracted == 0)
        }
         {
             dialogue.Talk();
             print("interacting");
            if (futureDialogueExists)
            {
                timesInteracted++;
            }
             return;

         }
        // change for every npc / entity
         if (timesInteracted == 1)
         {
            SetFutureDialogue(2, futureDialogue);
            string [] futureDialogue = { "Hello", "whats up"};
         }
         if (timesInteracted == 2)
         {
            string[] futureDialogue = { "How inefficient is this", "slightly better than last time", "yay!" };
            SetFutureDialogue(3, futureDialogue);
         }


         
        void SetFutureDialogue(int length, string[] dialogueLines)
        {
             for (int i = 0; i < length; i++)
             dialogue.lines = new string[length];
             {
                 dialogue.lines[i] = dialogueLines[i];
             dialogue.Talk();
             }
             return;
             timesInteracted++;
        }

        /*
        {
        if (hasInteracted == false)
            print("interacting");
            dialogue.Talk();
            if (futureDialogue.Length > 0)
            {
                hasInteracted = true;
            }
        }
        {
        if (hasInteracted == true)
            dialogue.Talk();
            dialogue.lines = futureDialogue;
        }
        */

    }
    [System.Serializable]
    public class VoiceLines
    {
        public string[] lines;
    }
}



