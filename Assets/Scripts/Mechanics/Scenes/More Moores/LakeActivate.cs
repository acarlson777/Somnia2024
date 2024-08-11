using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LakeActivate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterDialogue characterDialogue;

    // Update is called once per frame
    void Update()
    {
        if (characterDialogue.timesInteracted >= 1)
        {
            if (characterDialogue.character.lineNumber == characterDialogue.character.numberOfLines.Length-1) //might need a -1 here to work properly
            {
                InstantiateLoadingScreen.Instance.LoadNewScene("CS8 (Whale Mouth)");
            }
        }
    }
}
