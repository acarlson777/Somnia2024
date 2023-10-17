using UnityEngine;

public class SetDialogueBoxText : MonoBehaviour
{
    [HideInInspector] public GameObject dialogueBoxPrefab;
    public Canvas canvas;

    public string[] lines;

    private void Awake()
    {
        dialogueBoxPrefab = Resources.Load("DialogueBox") as GameObject;
    }

    public void Talk()
    {
        if (GameObject.Find("DialogueBox") == false)
        {
            GameObject dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
            dialogueBox.name = "DialogueBox";
            dialogueBox.GetComponent<DialogueScript>().SetText(lines.Length, lines);
        }
    }
}
