using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPicker : NonLiving, Entity
{

    InstantiateLoadingScreen loadingScreen;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
    }
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            loadingScreen.LoadNewScene("TrainTemplateCutScene");
        }
    }
}
