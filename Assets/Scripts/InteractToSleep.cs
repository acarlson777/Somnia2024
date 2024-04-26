using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToSleep : InteractableObject, Entity
{
    public string soundsToPlay;
    public List<Voicelines> lines;
    protected int timesInteracted = 0;
    public bool interacted = false;

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
            interacted = true;
            //AudioManagerSingleton.PlayRandomOnce(this.gameObject);
            //Find soundtrack using string name then play random once
            if (soundsToPlay != null && soundsToPlay.Length != 0) 
                AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce(soundsToPlay, this.gameObject);

        }
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
