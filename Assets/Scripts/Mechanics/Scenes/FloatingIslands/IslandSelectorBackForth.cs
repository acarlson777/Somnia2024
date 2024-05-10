using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelectorBackForth : NonLiving, Entity
{
    [SerializeField] public string[] lockedDialogue;
    public string showName;

    public string audioName;

    IslandSelectorBackForth[] otherSelectors; // Will contain a reference to all selectors (including us) in the scene, populated during Start

    [SerializeField] private bool locked = false;

    public string IslandName = "Unnamed";

    public bool isOn = true;

    void Awake()
    {
        if (locked) return;
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        otherSelectors = new IslandSelectorBackForth[others.Length];
        for (int i = 0; i < others.Length; i++) // does contain a reference to ourselves
        {
            otherSelectors[i] = others[i].GetComponent<IslandSelectorBackForth>();
        }
        TurnOff();
    }

    new void Start()
    {
        base.Start();
    }

    public void TurnOff()
    {
        if (locked) return;
        if (isOn)
        {
            isOn = false;
        }
    }

    new public void Interact(Entity entity)
    {

        if (locked)
        {
            DialogueManager.PopDialogue(lockedDialogue);
            return;
        }
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce(audioName, gameObject);

        if (!isOn) // if we are switchin' it on
        {
            // we make all other ones become off
            foreach (IslandSelectorBackForth i in otherSelectors)
            {
                i.TurnOff();
                i.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        isOn = !isOn;
        this.gameObject.GetComponent<SpriteRenderer>().flipX = isOn;
    }
}
