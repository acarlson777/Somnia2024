using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkidThroneRoom : MonoBehaviour
{
    CharacterDialogue character;
    [HideInInspector] public static bool talkedWith = false;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Woebegone.talkedWith) { character.disabled = true; }
        else character.disabled = false;
        if (character.timesInteracted >= character.lines.Count && Woebegone.talkedWith)
        {
            talkedWith = true;
        }
    }
}
