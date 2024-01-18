using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPicker : NonLiving, Entity
{
    public IslandSelector[] selectors;
    void Awake()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        selectors = new IslandSelector[others.Length];
        for (int i = 0; i < others.Length; i++) 
        {
            selectors[i] = others[i].GetComponent<IslandSelector>();
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            for (int i = 0; i < selectors.Length; i++)
            {
                if (selectors[i].isOn)
                {
                    DialogueManager.PopDialogue(new string[] { "Toot Toot, we are going to -> "+ selectors[i].IslandName, "idk what sound trains make sowy :(" });
                    InstantiateLoadingScreen.Instance.LoadNewScene(selectors[i].IslandName);
                }
            }
        }
    }
}
