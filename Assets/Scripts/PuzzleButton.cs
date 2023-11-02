using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : InteractableObject, Entity
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
            if (timesInteracted >= lines.Count)
            {
                timesInteracted = lines.Count - 1;
            }
            print(gameObject.name + " was pressed");
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
