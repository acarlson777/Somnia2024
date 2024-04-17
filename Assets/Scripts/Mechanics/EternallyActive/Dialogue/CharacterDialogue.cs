using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : InteractableObject, Entity
{
    public List<Voicelines> lines;
    public List<AudioLines> audioLines;
     public int timesInteracted = 0;

    [HideInInspector] public Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] new public string name;
    [HideInInspector] TextMeshProUGUI nameText;
    bool portraitSet = false;
    bool interactedWith = false;
    public bool disabled = false;

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
        if (disabled) {
            CharacterDialogueManager.PopCharacterDialogue(new string[] { "..." });
            timesInteracted = 0;
        }
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
            if (!disabled) timesInteracted++;

        }
        if (GameObject.Find("CharacterDialogueBox") != null && !portraitSet && interactedWith)
        {
            portrait = GameObject.Find("Portraits").GetComponent<Image>();
            nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
            nameText.text = name;
            portrait.sprite = characterPortrait;
            //portraitSet = true;
            interactedWith = false;
        }
    }

    new private void Update()
    {
        if (character != null)
        {
            if (prevLineNumber != character.lineNumber)
            {
                audioSource.clip = audioLines[timesInteracted-1].audioLines[character.lineNumber];
                audioSource.Play();
                prevLineNumber = character.lineNumber;
            }
        } else 
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
