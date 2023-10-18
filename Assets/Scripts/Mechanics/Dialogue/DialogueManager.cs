using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static Canvas canvas;
    private static GameObject dialogueBoxPrefab;
    void Awake()
    public Canvas DisplaySurface;
        dialogueBoxPrefab = Resources.Load("DialogueBox") as GameObject; // get the Dialogue Prefab in the Resources Folder named "DialogueBox"
    {
        canvas = DisplaySurface;
        print("Dialogue Manager is Being Set up");

    }
    ///   <para>Pops up a dialogue in the game, cannot pop if already active</para>
    /// <summary>
    ///   <para>Returns true if succeeded / false if failed</para>
    /// </summary>
    public static bool PopDialogue(string[] textLines)
    {
        // Step 1: Check if a Dialogue is currently active
        // Implementation 1: Check if a gameobject with the name of "DialogueBox" exists
        GameObject dialogueBox = GameObject.Find("DialogueBox");
        if (dialogueBox != null)
            return false;
            //Destroy(dialogueBox);
        {
        }
        // Step 2: Make a new DialogueBox with the textLines as before
        dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
        dialogueBox.GetComponent<DialogueScript>().SetText(textLines);
        dialogueBox.name = "DialogueBox"; // Set its name to "DialogueBox"
        return true;
    }

}
