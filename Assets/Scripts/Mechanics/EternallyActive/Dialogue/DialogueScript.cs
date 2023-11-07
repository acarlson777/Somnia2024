using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    // cached references
    public TextMeshProUGUI dialogueText;
    GameObject joystick;

    // variables for dialogue functionality
    public string[] numberOfLines;
    public float textSpeed;
    [SerializeField] int lineNumber;

    public bool isActive;

    // finds a joystick caches it
    private void Awake()
    {
        if (GameObject.Find("Joystick") != null)
        {
            joystick = GameObject.Find("Joystick");
        }
    }

    // sets joystick inactive and then starts writing text
    void Start()
    {
        if (joystick != null)
        {
            joystick.SetActive(false);
        }
        isActive = true;
        dialogueText.text = "";
        StartText();
    }

    void Update()
    {
        TextOnClick();
    }

    void StartText()
    {
        lineNumber = 0;
        StartCoroutine(WriteLine());
    }

    // sets the dialogue box's text from another script on another gameobject, taking in the length in lines of dialogue and the actual text
    public void SetText(string[] text)
    {
        numberOfLines = new string[text.Length];
        for (int line = 0; line < numberOfLines.Length; line++)
        {
            numberOfLines[line] = text[line];
        }
    }

    // progresses text box on click / autofills text on click
    void TextOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //MAKE IT WORK WITH MOBILE TOO THANKS - CAI
        {
            if (dialogueText.text != numberOfLines[lineNumber])
            {
                StopAllCoroutines();
                dialogueText.text = numberOfLines[lineNumber];
            }
            else
            {
                WriteNextLine();
            }
        }
    }

    // for every char in the line, add it to the text with delay
    IEnumerator WriteLine()
    {
        foreach (char letter  in numberOfLines[lineNumber])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // reset dialogue box, if no lines left to write, set joystick to active and delete dialogue box
    void WriteNextLine()
    {
        lineNumber++;
        dialogueText.text = string.Empty;
        if (lineNumber > numberOfLines.Length - 1)
        {
            if (joystick != null)
            {
                joystick.SetActive(true);
            }
           isActive = false;
           Destroy(gameObject);
        }
        // otherwise, continue printing next line
        else
        {
            StartCoroutine(WriteLine());
        }
    }
}
