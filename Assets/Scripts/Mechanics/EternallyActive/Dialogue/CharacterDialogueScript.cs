using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterDialogueScript : MonoBehaviour
{

    // cached references
    public TextMeshProUGUI dialogueText;
    GameObject joystick;
    GameObject interact_button;
    CharacterDialogueClickthrough charDialogue;
    [HideInInspector] public int index = -1;

    // variables for dialogue functionality
    public string[] numberOfLines;
    public float textSpeed;
    [SerializeField] public int lineNumber = 0;

    public bool isActive;
    [HideInInspector] public bool characterClickthroughDialogue = false;

    // finds a joystick caches it
    private void Awake()
    {
        isActive = true;

        GameObject js = GameObject.Find("Joystick");
        if (js != null)
        {
            joystick = js;
        }
        js = GameObject.Find("InteractButton");
        if (js != null)
        {
            interact_button = js;
        }
        if (FindObjectOfType<CharacterDialogueClickthrough>() != null)
        {
            charDialogue = FindObjectOfType<CharacterDialogueClickthrough>();
            characterClickthroughDialogue = true;
        }
    }

    // sets joystick inactive and then starts writing text
    void Start()
    {
        JoystickInput.worldOrientedJoystickDirection = new Vector3(0, 0, 0);

        if (joystick != null)
        {
            joystick.SetActive(false);
        }
        if (interact_button != null)
        {
            interact_button.SetActive(false);
        }
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
        foreach (char letter in numberOfLines[lineNumber])
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
            if (interact_button != null)
            {
                interact_button.SetActive(true);
            }
            isActive = false;
            Destroy(gameObject);
        }
        // otherwise, continue printing next line
        else
        {
            if (characterClickthroughDialogue)
            {
                charDialogue.lineNumber++;
                charDialogue.GetComponent<AudioSource>().clip = charDialogue.voiceAudio[lineNumber];
                charDialogue.GetComponent<AudioSource>().Play();
            }
            StartCoroutine(WriteLine());
        }
    }
}
