using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : InteractableObject, Entity
{
    public List<Voicelines> lines;
    public List<AudioLines> audioLines;
    private int timesInteracted = 0;

    [HideInInspector] public Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] public string name;
    [HideInInspector] TextMeshProUGUI nameText;
    bool portraitSet = false;
    bool interactedWith = false;

    private AudioSource audioSource;
    CharacterDialogueScript character;
    public int prevLineNumber;

    new protected void Start()
    {
        base.Start();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            portraitSet = false;
            interactedWith = true;
            if (timesInteracted >= lines.Count)
            {
                timesInteracted = lines.Count - 1;
            }
            print("putting a dialogue" + timesInteracted);
            CharacterDialogueManager.PopCharacterDialogue(lines[timesInteracted].lines);
            audioSource.clip = audioLines[timesInteracted].audioLines[0];
            audioSource.Play();
            character = FindObjectOfType<CharacterDialogueScript>();
            timesInteracted++;

        }
        if (GameObject.Find("CharacterDialogueBox") != null && !portraitSet && interactedWith)
        {
            portrait = GameObject.Find("Portraits").GetComponent<Image>();
            nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
            nameText.text = name;
            portrait.sprite = characterPortrait;
            portraitSet = true;
            interactedWith = false;
        }
    }

    private void Update()
    {
        if (character != null)
        {
            if (prevLineNumber != character.lineNumber)
            {
                audioSource.clip = audioLines[timesInteracted-1].audioLines[character.lineNumber];
                audioSource.Play();
                prevLineNumber = character.lineNumber;
            }
        }
        if (character == null)
        {
           audioSource.Stop();
        }
    }

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
    [System.Serializable]
    public class AudioLines
    {
        public AudioClip[] audioLines;
    }
}
