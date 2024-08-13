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
    [SerializeField] private List<Portraits> characterPortraits;
    [SerializeField] private List<Names> names;
    [SerializeField] bool oneCharacter;
    [HideInInspector] TextMeshProUGUI nameText;
    bool portraitSet = false;
    public bool interactedWith = false;
    public bool disabled = false;

    public AudioSource audioSource;
    public CharacterDialogueScript character;
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
            if (oneCharacter)
            {
                CharacterDialogueManager.PopCharacterDialogue(lines[timesInteracted].lines);
            } else
            {
                CharacterDialogueManager.PopCharacterDialogue(lines[timesInteracted].lines, names[timesInteracted].names, characterPortraits[timesInteracted].portraits);
            }
            

            audioSource.clip = audioLines[timesInteracted].lines[0].audio;
            audioSource.volume = audioLines[timesInteracted].lines[0].volume * PlayerPrefs.GetFloat("sfxVolume");

            print("HALLO");
            audioSource.Play();
            
            character = FindObjectOfType<CharacterDialogueScript>();
            if (!disabled) timesInteracted++;

        }
        if (GameObject.Find("CharacterDialogueBox") != null && !portraitSet && interactedWith)
        {
            portrait = GameObject.Find("Portraits").GetComponent<Image>();
            nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
            if (oneCharacter) 
            {
                nameText.text = names[0].names[0];
                portrait.sprite = characterPortraits[0].portraits[0];
            }
            //portraitSet = true;
        }
    }

    new private void Update()
    {
        if (character != null)
        {
            if (prevLineNumber != character.lineNumber)
            {
                print(timesInteracted);
                print(character.lineNumber);
                audioSource.clip = audioLines[timesInteracted-1].lines[character.lineNumber].audio;
                audioSource.volume = audioLines[timesInteracted - 1].lines[character.lineNumber].volume * PlayerPrefs.GetFloat("sfxVolume");
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
        public SoundEffect[] lines;
    }
    [System.Serializable]
    public class Names
    {
        public string[] names;
    }
    [System.Serializable]
    public class Portraits
    {
        public Sprite[] portraits;
    }
    [System.Serializable]
    public class SoundEffect
    {
        public AudioClip audio;
        [Range(0, 1)]
        public float volume = 1 ;
    }
}
