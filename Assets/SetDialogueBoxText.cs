using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueBoxText : MonoBehaviour
{

    DialogueScript dialogueScript;
    public int dialogueLength;
    public string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("DialogueBox").GetComponent<DialogueScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            dialogueScript.SetText(lines.Length, lines);
        }
    }
}
