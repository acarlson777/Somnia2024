using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTNPC : Living,Entity
{

    SetDialogueBoxText dialogue;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dialogue = gameObject.GetComponent<SetDialogueBoxText>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity entity) // Interact is a method which can be overridden but does not need to call the base version
    {
        print("interacting");
        dialogue.Talk();
    }
}
