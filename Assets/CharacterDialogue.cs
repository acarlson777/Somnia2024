using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : InteractableObject, Entity
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    bool sceneChanged = false;
    bool startedDialogue = false;

    Image portrait;
    [SerializeField] Sprite characterPortrait;
    [SerializeField] string name;
    [HideInInspector] TextMeshProUGUI nameText;

    new protected void Start()
    {
        base.Start();
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
            DialogueManager.PopDialogue(lines[timesInteracted].lines);
            portrait = GameObject.Find("Portraits").GetComponent<Image>();
            portrait.sprite = characterPortrait;
            timesInteracted++;

        }
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
