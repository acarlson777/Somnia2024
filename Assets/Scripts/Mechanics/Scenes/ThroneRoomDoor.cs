using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroneRoomDoor : InteractableObject, Entity
{
    InstantiateLoadingScreen loadingScreen;
    private bool ready = true;
    public string[] not_ready_dialogue;
    new void Start()
    {
        base.Start();
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
    }

    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            if (ready)
            {
                loadingScreen.LoadANewScene();
            }
            else
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
