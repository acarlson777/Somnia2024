/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfgang : Living, Entity
{
    // references to all of the island selectors
    public IslandSelector[] selectors;
    public bool firstTime = true;

    //CharacterDialogue character;
    //public Sprite wolfgangPortrait;
    // Start is called before the first frame update
    public void Awake()

    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        selectors = new IslandSelector[others.Length];
        for (int i = 0; i < others.Length; i++) 
        {
            selectors[i] = others[i].GetComponent<IslandSelector>();
        }
    }
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    private string getSelectedName()
    {
        for (int i = 0; i < selectors.Length; i++)
        {
            if (selectors[i].isOn)
            {
                return selectors[i].IslandName;
            }
        }
        return null;
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (firstTime)
            {
                firstTime = false;
                string island = getSelectedName();
                if (island == null)
                {
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "Hello", "My name is Wolfgang (im a not a wolf in a gang)", "You should probably interact with the emmas" });
                }
                else
                {
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "Hello", "My name is Wolfgang (im a not a wolf in a gang)", "You seem to want to go to " + island, "please proceed onto the train!" });

                }
            }
            else
            {
                string island = getSelectedName();
                if (island == null)
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "You should probably interact with the emmas" });
                else
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "Destination: " + island, "Please board the train...", "OR ELSE!!!! >;)" });
            }
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wolfgang : Living, Entity
{
    public List<Voicelines> lines;
    public List<AudioLines> audioLines;
    private int timesInteracted = 0;

    public IslandSelectorBackForth[] selectors;
    public bool firstTime = true;

    public string[] firstTimeDialogue;

    [HideInInspector] public Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] new public string name;
    [SerializeField] TextMeshProUGUI nameText;
    bool portraitSet = false;
    bool interactedWith = false;

    private AudioSource audioSource;
    CharacterDialogueScript character;
    public int prevLineNumber;

    public void Awake()

    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        selectors = new IslandSelectorBackForth[others.Length];
        for (int i = 0; i < others.Length; i++)
        {
            selectors[i] = others[i].GetComponent<IslandSelectorBackForth>();
        }
    }

    new protected void Start()
    {
        base.Start();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private string getSelectedName()
    {
        for (int i = 0; i < selectors.Length; i++)
        {
            if (selectors[i].isOn)
            {
                return selectors[i].IslandName;
            }
        }
        return null;
    }
    private string getSelectedShowName()
    {
        for (int i = 0; i < selectors.Length; i++)
        {
            if (selectors[i].isOn)
            {
                return selectors[i].showName;
            }
        }
        return null;
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            portraitSet = false;
            interactedWith = true;
            print(timesInteracted);
            audioSource.clip = audioLines[timesInteracted].audioLines[0];
            audioSource.Play();

            if (firstTime)
            {
                firstTime = false;
                string island = getSelectedName();
                string show = getSelectedShowName();
              
                if (island == null)
                {
                    CharacterDialogueManager.PopCharacterDialogue(firstTimeDialogue);
                }
                else
                {
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "Hello", "My name is Wolfgang", "You seem to want to go to " + show, "please proceed onto the train!" });

                }
            }
            else
            {
                string island = getSelectedName();
                string show = getSelectedShowName();
                if (island == null)
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "You should probably interact with the boxes" });
                else
                    CharacterDialogueManager.PopCharacterDialogue(new string[] { "Destination: " + show, "Please board the train..." });
            }

            print("putting a dialogue" + timesInteracted);
            //audioSource.clip = audioLines[timesInteracted].audioLines[0];
            //audioSource.Play();
            character = FindObjectOfType<CharacterDialogueScript>();
            timesInteracted++;
            if (timesInteracted >= audioLines.Count)
            {
                timesInteracted = audioLines.Count - 1;
            }

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
                audioSource.volume = 0.8f*PlayerPrefs.GetFloat("sfxVolume");
                audioSource.Play();
                prevLineNumber = character.lineNumber;
            }
        }
        else
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
