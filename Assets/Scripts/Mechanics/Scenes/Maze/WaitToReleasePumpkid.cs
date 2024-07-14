using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToReleasePumpkid : MonoBehaviour
{
    private CharacterDialogueClickthrough characterDialogueClickthrough;
    [SerializeField] private GameObject pumpkid1;
    [SerializeField] private GameObject pumpkid2;
    private bool hasActivated = false;


    private void Start()
    {
        characterDialogueClickthrough = FindObjectOfType<CharacterDialogueClickthrough>();
    }

    void Update()
    {
        if (characterDialogueClickthrough.lineNumber >= 4 && !hasActivated)
        {
            pumpkid1.SetActive(false);
            pumpkid2.SetActive(true);
            hasActivated = true;
        }
    }
}
