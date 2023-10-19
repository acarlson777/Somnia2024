using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : NPCs,Entity
{
    public List<VoiceLines> dialogueList;
    public int timesInteracted = 0;

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        print(dialogueList.Capacity);
    }

    // on interaction, open the dialogue box and start writing text that is set in the inspector
    new public void Interact(Entity entity)
    {

        if (timesInteracted >= dialogueList.Capacity)
        {
            timesInteracted = dialogueList.Capacity-1;
        }
        DialogueManager.PopDialogue(dialogueList[timesInteracted].lines);
        timesInteracted++;
    }
    
    [System.Serializable]
    public class VoiceLines
    {
        public string[] lines;
    }
}



