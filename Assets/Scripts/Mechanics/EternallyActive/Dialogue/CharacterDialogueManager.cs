using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject dialogueBoxPrefab;
    private static Canvas canvas;
    public Canvas DisplaySurface;
    void Awake()
    {
        dialogueBoxPrefab = Resources.Load("CharacterDialogueBox") as GameObject; // get the Dialogue Prefab in the Resources Folder named "CharacterDialogueBox"
        if (dialogueBoxPrefab == null)
        {
            print("Dialogue box not found!!!!");
        }
        canvas = DisplaySurface;
        print("Dialogue Manager is Being Set up");
    }



    /// <summary>
    ///   <para>Pops up a dialogue in the game, cannot pop if already active</para>
    ///   <para>Returns true if succeeded / false if failed</para>
    /// </summary>
    public static bool PopCharacterDialogue(string[] textLines)
    {
        if (textLines == null || textLines.Length == 0) return false;
        // Step 1: Check if a Dialogue is currently active
        // Implementation 1: Check if a gameobject with the name of "CharacterDialogueBox" exists
        GameObject dialogueBox = GameObject.Find("CharacterDialogueBox");
        if (dialogueBox != null)
        {
            return false;
        }
        // Step 2: Make a new DialogueBox with the textLines as before
#if UNITY_EDITOR

        if (dialogueBoxPrefab == null)
        {
            dialogueBoxPrefab = Resources.Load("CharacterDialogueBox") as GameObject;
        }
        if (canvas == null)
        {
            print("Cannot Display Dialogue in reloaded Scene, please manually stop and restart it.");
            print("However, this and the prior line are from PopDialogue which DID end up being called.");
            return false;
        }
#endif
        dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
        dialogueBox.name = "CharacterDialogueBox"; // Set its name to "CharacterDialogueBox"
        dialogueBox.GetComponent<CharacterDialogueScript>().SetText(textLines);
        return true;
    }

    public static bool PopCharacterDialogue(string[] textLines, string[] names, Sprite[] characterPortraits)
    {
        if (textLines == null || textLines.Length == 0) return false;
        // Step 1: Check if a Dialogue is currently active
        // Implementation 1: Check if a gameobject with the name of "CharacterDialogueBox" exists
        GameObject dialogueBox = GameObject.Find("CharacterDialogueBox");
        if (dialogueBox != null)
        {
            return false;
        }
        // Step 2: Make a new DialogueBox with the textLines as before
#if UNITY_EDITOR

        if (dialogueBoxPrefab == null)
        {
            dialogueBoxPrefab = Resources.Load("CharacterDialogueBox") as GameObject;
        }
        if (canvas == null)
        {
            print("Cannot Display Dialogue in reloaded Scene, please manually stop and restart it.");
            print("However, this and the prior line are from PopDialogue which DID end up being called.");
            return false;
        }
#endif
        dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
        dialogueBox.name = "CharacterDialogueBox"; // Set its name to "CharacterDialogueBox"
        dialogueBox.GetComponent<CharacterDialogueScript>().SetText(textLines, names, characterPortraits);
        return true;
    }
}
