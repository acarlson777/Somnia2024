using UnityEngine;
using System.Collections;

public class ThroneRoomDoorForReal : InteractableObject, Entity
{
    public string sceneName;
    bool locked = true;

    new private void Update()
    {
        if (Woebegone.talkedWith)
        {
            if (PumpkidThroneRoom.talkedWith) locked = false;
        } 
    }

    new public void Interact(Entity other)
    {
        if (other is Player && !locked)
        {
            gameObject.GetComponent<SceneClickThrough>().StartClickThrough();
        }
        else DialogueManager.PopDialogue(new string[] { "I should talk to the others first." });
    }
}