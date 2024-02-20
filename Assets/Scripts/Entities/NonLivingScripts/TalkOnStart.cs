using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOnStart : DialogueAndMagic, Entity
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        DialogueManager.PopDialogue(lines[0].lines);
        timesInteracted++;
    }

    // Update is called once per frame
   
}
