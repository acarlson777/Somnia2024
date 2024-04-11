using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeasBedScript : InteractableObject, Entity
{
    public GameObject[] itemsToSleep;
    int itemCount;
    public static bool noHostileMobsAround = false;
    public bool inspectorBed = false;
    public string[] not_ready_dialogue;
    public string sceneToLoad;
    new void Start()
    {
        base.Start();
        itemCount = itemsToSleep.Length;
 
    }

    new void Update()   
    {
        base.Update();
 
    }
    new public void Interact(Entity other)
    {
        int temp = 0;
        foreach (GameObject item in itemsToSleep)
        {
            if (item.GetComponent<InteractToSleep>().interacted) temp++;
        }
        if (temp == itemCount) inspectorBed = true;
        if (other is Player)
        {
            if (noHostileMobsAround && inspectorBed)
            {
                if (gameObject.GetComponent<SceneClickThrough>() != null) gameObject.GetComponent<SceneClickThrough>().StartClickThrough();
                else InstantiateLoadingScreen.Instance.LoadNewScene(sceneToLoad);
                AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("BeasRoom", 1);
            } else
            {
                DialogueManager.PopDialogue(not_ready_dialogue);
            }
                
        }
    }
    [System.Serializable]
    public class DialogueLines
    {
        public string[] lines;
    }
}
