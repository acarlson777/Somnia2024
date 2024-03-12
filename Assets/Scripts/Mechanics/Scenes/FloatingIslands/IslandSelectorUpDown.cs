using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelectorUpDown : NonLiving, Entity
{
    [SerializeField] public  string[] lockedDialogue;
    //PUT VARS HERE
    private Vector3 startPos;
    private Vector3 endPos;
    public float symbolSpeed = 1.0f;
    [SerializeField] public float symbolEndDistance = -0.5f;

    IslandSelector[] otherSelectors; // Will contain a reference to all selectors (including us) in the scene, populated during Start

    [SerializeField] private bool locked = false;
    
    public string IslandName = "Unnamed";

    public bool isOn = true;

    void Awake()
    {
        base.Start();
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + symbolEndDistance, startPos.z);

        if (locked) return;
        GameObject[] others =  GameObject.FindGameObjectsWithTag("TrainSelector");
        otherSelectors = new IslandSelector[others.Length];
        for (int i = 0; i < others.Length;i++) // does contain a reference to ourselves
        {
            otherSelectors[i] = others[i].GetComponent<IslandSelector>();
        }
        TurnOff();
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
        if (!isOn) // if we are switchin' it on
        {
            // we make all other ones become off
            foreach (IslandSelector i in otherSelectors)
            {
                i.TurnOff();
            }
        }
        isOn = !isOn;
    }

    public new void Update()
    {
        base.Update();
        if (isOn)
        {
            // Move down so that half is showing
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * symbolSpeed);
        }
        else
        {
            // Move back up so that all is showing
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * symbolSpeed);
        }
    }
}
