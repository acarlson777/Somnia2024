using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject dialogueBoxPrefab;
    private static Canvas canvas;
    public Canvas DisplaySurface;
    void Awake()
    {
        dialogueBoxPrefab = Resources.Load("DialogueBox") as GameObject; // get the Dialogue Prefab in the Resources Folder named "DialogueBox"
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
    public static bool PopDialogue(string[] textLines)
    {
        if (textLines == null || textLines.Length == 0) return false;
        // Step 1: Check if a Dialogue is currently active
        // Implementation 1: Check if a gameobject with the name of "DialogueBox" exists
        GameObject dialogueBox = GameObject.Find("DialogueBox");
        if (dialogueBox != null)
        {
            return false;
        }
        // Step 2: Make a new DialogueBox with the textLines as before
#if UNITY_EDITOR

        if (dialogueBoxPrefab == null) {
            dialogueBoxPrefab = Resources.Load("DialogueBox") as GameObject; 
        }
        if (canvas == null) {
            print("Cannot Display Dialogue in reloaded Scene, please manually stop and restart it.");
            print("However, this and the prior line are from PopDialogue which DID end up being called.");
            return false;
        }
#endif
        dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
        dialogueBox.name = "DialogueBox"; // Set its name to "DialogueBox"
        dialogueBox.GetComponent<DialogueScript>().SetText(textLines);
        return true;
    }

}
