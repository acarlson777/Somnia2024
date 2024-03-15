using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImprisonedRiggs : InteractableObject, Entity
{
    public static int count = 0;
    public List<DialogueLines> lines;
    public bool exitIsActive = false;

    new private void Start()
    {
        base.Start();
    }

    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            if (count >= lines.Count)
            {
                count = lines.Count - 1;
            }
            
            if (count == 0)
            {
                exitIsActive = true;
            }

            DialogueManager.PopDialogue(lines[count].lines);

            count++;
        }
    }

    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}

