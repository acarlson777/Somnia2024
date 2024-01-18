using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelector : NonLiving, Entity
{
    // Start is called before the first frame update
    IslandSelector[] otherSelectors; // Will contain a reference to all selectors (including us) in the scene, populated during Start
    [SerializeField] Material offMaterial;
    [SerializeField] Material onMaterial;
    public string IslandName = "Unnamed";

    public bool isOn = true;

    void Awake()
    {
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
        if (isOn)
        {
            gameObject.GetComponent<Renderer>().material = offMaterial;        // unlights itself 
            isOn = false;
        }
    }

    new public void Interact(Entity entity)
    {
        if (!isOn) // if we are switchin' it on
        {
            // we make all other ones become off
            foreach (IslandSelector i in otherSelectors)
            {
                i.TurnOff();
            }
        }
        isOn = !isOn;

        gameObject.GetComponent<Renderer>().material = isOn? onMaterial : offMaterial;
    }
}
