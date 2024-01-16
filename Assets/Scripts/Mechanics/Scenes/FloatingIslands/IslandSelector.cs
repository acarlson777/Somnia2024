using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelector : NonLiving, Entity
{
    // Start is called before the first frame update
    GameObject[] otherSelectors; // Will contain a reference to all other selectors in the scene, populated during Start
    bool isOn = false;

    void Awake()
    {
        GameObject[] others =  GameObject.FindGameObjectsWithTag("TrainSelector");
        otherSelectors = new GameObject[others.Length-1];
        for (int i = 0, othersIndex = 0; i < otherSelectors.Length; i++,othersIndex++)
        {
            if (others[othersIndex] == this)
            {
                othersIndex++;
            }
            otherSelectors[i] = others[othersIndex];   
        }
    }
    public void TurnOff()
    {
        isOn = false;
    }

    new void Interact(Entity interactee)
    {
        isOn = !isOn;
        if (isOn) // if we are switchin' it on
        {
            // we make all other ones become off
        }
    }
}
