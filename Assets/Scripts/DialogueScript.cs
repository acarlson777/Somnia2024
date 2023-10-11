using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;

    public string[] numberOfLines;
    public float textSpeed;

    [SerializeField] int lineNumber;

    public bool isActive;


    void Start()
    {
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

    public void SetText(int arrayLength, string[] text)
    {
        numberOfLines = new string[arrayLength];
        for (int line = 0; line <= numberOfLines.Length -1; line++)
        {
            numberOfLines[line] = text[line];
        }
    }


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
        string currentLine = numberOfLines[lineNumber];
        foreach (char letter  in currentLine)
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
           isActive = false;
           gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(WriteLine());
        }
    }


}
