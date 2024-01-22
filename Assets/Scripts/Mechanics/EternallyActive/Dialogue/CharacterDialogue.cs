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
    bool portraitSet = false;
    bool interactedWith = false;

    new protected void Start()
    {
        base.Start();
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
    }

    private void Update()
    {
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

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
