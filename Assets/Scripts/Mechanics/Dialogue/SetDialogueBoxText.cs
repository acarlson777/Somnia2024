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

    void Update()
    {
        // temporary, will later be checking if the player interacts with this gameobjec
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject dialogueBox = Instantiate(dialogueBoxPrefab, canvas.transform);
            dialogueBox.GetComponent<DialogueScript>().SetText(lines.Length, lines);
        }
    }
}
