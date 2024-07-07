using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PressurePlatePrisonBarsButton : InteractableObject, Entity
{
    public GameObject barsToRemove;
    public List<Voicelines> lines;
    public List<AudioLines> audioLines;
    public int timesInteracted = 0;

    [HideInInspector] public Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] new public string name;
    [HideInInspector] TextMeshProUGUI nameText;
    private AudioSource audioSource;
    CharacterDialogueScript character;
    public int prevLineNumber;
    bool portraitSet = false;
    bool interactedWith = false;

    new private void Start()
    {
        base.Start();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (timesInteracted >= lines.Count)
            {
                timesInteracted = lines.Count - 1;
            }
            print("putting a dialogue" + timesInteracted);

            // Logic here

            if (timesInteracted == 0)
            {
                barsToRemove.SetActive(false);
            }

            CharacterDialogueManager.PopCharacterDialogue(lines[timesInteracted].lines);
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

    new private void Update()
    {
        if (character != null)
        {
            if (prevLineNumber != character.lineNumber)
            {
                audioSource.clip = audioLines[timesInteracted - 1].audioLines[character.lineNumber];
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
