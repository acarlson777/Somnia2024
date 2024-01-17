using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSelector : NonLiving, Entity
{
    // Start is called before the first frame update
    IslandSelector[] otherSelectors; // Will contain a reference to all other selectors in the scene, populated during Start
    [SerializeField] Material offMaterial;
    [SerializeField] Material onMaterial;

    bool isOn = true;

    void Awake()
    {
        GameObject[] others =  GameObject.FindGameObjectsWithTag("TrainSelector");
        TurnOff();
        otherSelectors = new IslandSelector[others.Length-1];
        for (int i = 0, othersIndex = 0; i < otherSelectors.Length; i++,othersIndex++)
        {
            if (others[othersIndex] == this)
            {
                othersIndex++;
            }
            try
            {
                otherSelectors[i] = others[othersIndex].GetComponent<IslandSelector>();
            } catch
            {
                Debug.Log("Train Selector doesn't have the component IslandSelector");
            }
        }
    }

    public void TurnOff()
    {
        if (isOn)
            gameObject.GetComponent<Renderer>().material = offMaterial;
        isOn = false;    
        // unlights itself 
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
