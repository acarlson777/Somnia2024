using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{

    public List<VoiceLines> tee;

    public int timesInteracted = 0;


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
        if (timesInteracted > tee.Count-1)
        {
            timesInteracted = tee.Count-1;
        }
        DialogueManager.PopDialogue(tee[timesInteracted].lines);
        timesInteracted++;
    }

    /*public void _Interact(Entity entity) // Interact is a method which can be overridden but does not need to call the base version
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
        

    }
    */
    [System.Serializable]
    public class VoiceLines
    {
        public string[] lines;
    }
}



