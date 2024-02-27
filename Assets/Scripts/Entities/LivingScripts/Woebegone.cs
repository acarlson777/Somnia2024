using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woebegone : MonoBehaviour
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
        if (character.timesInteracted >= character.lines.Count)
        {
            talkedWith = true;
        }
    }
}
