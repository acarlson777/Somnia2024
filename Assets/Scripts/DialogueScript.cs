using System.Collections;
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

    void StartText()
    {
        lineNumber = 0;
        StartCoroutine(WriteLine());
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
        StartCoroutine(WriteLine());
        if (lineNumber > numberOfLines.Length - 1)
        {
            isActive = false;
            gameObject.SetActive(false);
        }
        
    }


}
