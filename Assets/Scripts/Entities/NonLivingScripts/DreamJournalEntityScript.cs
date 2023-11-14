using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DreamJournalEntityScript : InteractableObject , Entity
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    new protected void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (timesInteracted == lines.Count)
            {
                PopupManager.CreatePopUp("DreamJournalPopup");
                return;
            }
            if (timesInteracted >= lines.Count)
            {
                timesInteracted = lines.Count-1;
            }
            print("putting a dialogue" + timesInteracted);
            DialogueManager.PopDialogue(lines[timesInteracted].lines);
            timesInteracted++;

        }
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
