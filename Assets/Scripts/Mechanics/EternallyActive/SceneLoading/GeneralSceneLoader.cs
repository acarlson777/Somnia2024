using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put on generic things like doors to load another scene
public class GeneralSceneLoader : InteractableObject, Entity
{
    InstantiateLoadingScreen sceneLoader;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        sceneLoader = GetComponent<InstantiateLoadingScreen>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            sceneLoader.LoadNewScene("");
        }
    }
}
