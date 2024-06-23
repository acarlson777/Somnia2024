using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToEveryoneManager : MonoBehaviour
{
    public CharacterDialogue[] characters;
    public Door door;

    void Update()
    {
        if (BeaTalkedToAllOthers())
        {
            door.enabled = true;
        }
    }

    private bool BeaTalkedToAllOthers()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].timesInteracted < 1)
            {
                return false;
            }
        }
        return true;
    }
}
