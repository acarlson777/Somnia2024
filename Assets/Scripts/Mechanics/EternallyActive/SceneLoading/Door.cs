using UnityEngine;
using System.Collections;

public class Door : InteractableObject, Entity
{
    public string sceneName;

    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
        }
    }
}