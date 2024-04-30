using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPicker : NonLiving, Entity
{
    public IslandSelectorBackForth[] selectors;
    void Awake()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("TrainSelector");
        selectors = new IslandSelectorBackForth[others.Length];
        for (int i = 0; i < others.Length; i++) 
        {
            selectors[i] = others[i].GetComponent<IslandSelectorBackForth>();
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
                    DialogueManager.PopDialogue(new string[] { "All aboard the Chew Choo Train! We are going to -> "+ selectors[i].showName });
                    InstantiateLoadingScreen.Instance.LoadNewScene(selectors[i].IslandName);
                }
            }
        }
    }
}
