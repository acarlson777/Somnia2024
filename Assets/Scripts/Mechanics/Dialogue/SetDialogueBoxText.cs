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
            //Talk();
            print("TRYING TO DIALOGUE but this is only for debug??? PURPOSES DO YEAH...");
            return;
        }
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
