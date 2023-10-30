using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TESTNPC : NPCs,Entity
{
    public List<Voicelines> dialogueList;
    public int timesInteracted = 0;

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
    }

    // on interaction, open the dialogue box and start writing text that is set in the inspector
    new public void Interact(Entity entity)
    {
        print(dialogueList.Count);

        if (timesInteracted >= dialogueList.Count)
        {
            timesInteracted = dialogueList.Count-1;
        }
        DialogueManager.PopDialogue(dialogueList[timesInteracted].lines);
        timesInteracted++;
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }

}   