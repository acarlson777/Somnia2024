using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LakeActivate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterDialogue characterDialogue;
    private CharacterDialogueScript characterDialogueScript;

    // Update is called once per frame
    void Update()
    {
        if (characterDialogue.timesInteracted >= 1)
        {
            characterDialogueScript = FindObjectOfType<CharacterDialogueScript>();
            if (characterDialogueScript.lineNumber == characterDialogueScript.numberOfLines.Length-1) //might need a -1 here to work properly
            {
                InstantiateLoadingScreen.Instance.LoadNewScene("CS8 (Whale Mouth)");
            }
        }
    }
}
