using UnityEngine;

public class SetDialogueBoxText : MonoBehaviour
{
    [HideInInspector] public GameObject dialogueBoxPrefab;
    public Canvas canvas;

    public string[] lines;

    private void Awake()
    {
        dialogueBoxPrefab = Resources.Load("DialogueBox") as GameObject; // get the Dialogue Prefab in the Resources Folder named "DialogueBox"
    }

    public void Talk()
    {
        if (GameObject.Find("DialogueBox") == null) // If DialogueBox doesn't exist in the scene yet
        {
            GameObject dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
            dialogueBox.name = "DialogueBox"; // Set its name to "DialogueBox"
            dialogueBox.GetComponent<DialogueScript>().SetText(lines);
        }
    }
}
