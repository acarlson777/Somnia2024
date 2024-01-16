using UnityEngine;
using System.Collections;

public class MazeMusicFadeOutHandler : InteractableObject, Entity
{
    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("MazeSoundtrack", 1f);
            InstantiateLoadingScreen.Instance.LoadNewScene("Bea's Room");
        }
    }
}

