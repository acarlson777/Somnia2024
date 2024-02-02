using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : InteractableObject, Entity
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;

    [SerializeField] Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] string name;
    [HideInInspector] TextMeshProUGUI nameText;
    public AudioClip[] voiceLines;
    bool portraitSet = false;
    bool interactedWith = false;
    [HideInInspector] public bool audioPlayed = false;

    private AudioSource audioSource;
    CharacterDialogueScript character;
    GameObject dialogueBox;

    private void Awake()
    {
        dialogueBox = Resources.Load("CharacterDialogueBox") as GameObject;
        character = dialogueBox.GetComponent<CharacterDialogueScript>();
    }

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

        if (!audioPlayed && dialogueBox.activeInHierarchy && this.voiceLines.Length > 0)
        {
            //if (audioSource.clip == null) throw new System.Exception("A character in the scene does not have any voicelines");
            audioSource.clip = voiceLines[character.lineNumber];
            audioSource.Play();
            audioPlayed = true;
        }
    }

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
