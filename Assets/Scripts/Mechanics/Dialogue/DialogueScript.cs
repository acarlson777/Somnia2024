using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    GameObject joystick;

    public string[] numberOfLines;
    public float textSpeed;
    [SerializeField] int lineNumber;

    public bool isActive;

    private void Awake()
    {
        joystick = GameObject.Find("Joystick");
    }

    void Start()
    {
        joystick.SetActive(false);
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
    public void SetText(int arrayLength, string[] text)
    {
        numberOfLines = new string[arrayLength];
        for (int line = 0; line < numberOfLines.Length; line++)
        {
            numberOfLines[line] = text[line];
        }
    }

    // progresses text box on click / autofills text on click
    void TextOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

    IEnumerator WriteLine()
    {
        foreach (char letter  in numberOfLines[lineNumber])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void WriteNextLine()
    {
        lineNumber++;
        dialogueText.text = string.Empty;
        if (lineNumber > numberOfLines.Length - 1)
        {
            joystick.SetActive(true);
           isActive = false;
           Destroy(gameObject);
        }
        else
        {
            StartCoroutine(WriteLine());
        }
    }
}
