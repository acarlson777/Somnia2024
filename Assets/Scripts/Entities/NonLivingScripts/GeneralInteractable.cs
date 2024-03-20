using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInteractable : InteractableObject, Entity
{
    new public AudioClip audio;
    public List<Voicelines> lines;
    protected int timesInteracted = 0;
    InstantiateLoadingScreen loadingScreen;

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
