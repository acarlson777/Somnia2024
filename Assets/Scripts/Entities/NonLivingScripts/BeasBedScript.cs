using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeasBedScript : InteractableObject, Entity
{
    public static bool noHostileMobsAround = false;
    public bool inspectorBed = false;
    InstantiateLoadingScreen loadingScreen;
    new void Start()
    {
        base.Start();
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
    }

    new void Update()   
    {
        base.Update();
        inspectorBed = noHostileMobsAround;
    }
    new public void Interact(Entity other)
    {
        Debug.Log("hi");
        if (other is Player)
        {
            Debug.Log("yooooooo");
            if (noHostileMobsAround)
            {
                loadingScreen.LoadANewScene();
            }
                
        }
    }
}
