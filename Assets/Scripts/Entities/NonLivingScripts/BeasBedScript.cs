using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeasBedScript : InteractableObject, Entity
{
    public static bool noHostileMobsAround = false;
    public bool inspectorBed = false;
    InstantiateLoadingScreen loadingScreen;
    public string[] not_ready_dialogue;
    new void Start()
    {
        base.Start();
        loadingScreen = FindObjectOfType<InstantiateLoadingScreen>();
    }

    new void Update()   
    {
        base.Update();
        inspectorBed = noHostileMobsAround;
    }
    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            if (noHostileMobsAround)
            {
                loadingScreen.LoadNewScene("Maze");
                AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("BeasRoom", 1);
            } else
            {
                DialogueManager.PopDialogue(not_ready_dialogue);
            }
                
        }
    }
    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}
