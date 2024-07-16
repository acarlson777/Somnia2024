using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostPressurePlatesRiggsHandler : MonoBehaviour
{
    [SerializeField] private CharacterDialogue postPressurePlatesRiggs;
    [SerializeField] private RiggsManager riggsManager;
    public bool shouldActivateExit = false;

    void Update()
    {
        if (postPressurePlatesRiggs.timesInteracted == postPressurePlatesRiggs.lines.Count)
        {
            shouldActivateExit = true;
            riggsManager.switchToNextRiggs();
        }
    }
}