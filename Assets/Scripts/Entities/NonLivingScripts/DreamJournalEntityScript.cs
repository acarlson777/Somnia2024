using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DreamJournalEntityScript : MonoBehaviour
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            timesInteracted++;
            if (timesInteracted <= lines.Count)
            {
                timesInteracted = lines.Count;
            }
            DialogueManager.PopDialogue(lines[timesInteracted].lines);
        }
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
