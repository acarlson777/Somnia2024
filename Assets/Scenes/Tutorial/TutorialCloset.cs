using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the closet for the tutorial
/// A Closet Tutorial if you will.
/// EPIC EPIC
/// currently listening to: El Perdedor: Enrique Iglesias
/// </summary>
public class TutorialCloset : DialogueAndMagic
{
    public string[] onEnterLines;
    public bool entered = false;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("entity"))
        {
            if (other.gameObject.name.Equals("Bea"))
            {
                if (!entered)
                {
                    entered = true;
                    DialogueManager.PopDialogue(ParseTalks(onEnterLines));
                    return;
                }

            }
        }
    }
    [System.Serializable]
    public class VoiceLines {
        public string[] lines;
    }

}
