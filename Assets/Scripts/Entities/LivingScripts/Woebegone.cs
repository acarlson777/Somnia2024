using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woebegone : MonoBehaviour
{

    CharacterDialogue character;
    [HideInInspector] public static bool talkedWith = false;
    public Door door;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.timesInteracted >= 1)
        {
            talkedWith = true;
        }

        if (door != null)
        {
            door.enabled = talkedWith;
        }
    }
}
