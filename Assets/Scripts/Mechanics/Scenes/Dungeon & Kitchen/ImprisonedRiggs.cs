using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImprisonedRiggs : MonoBehaviour
{
    public bool exitIsActive = false;

    public void Update()
    {
        CharacterDialogue d = GetComponent<CharacterDialogue>();
        exitIsActive = d.timesInteracted == d.lines.Count;
    }


}

