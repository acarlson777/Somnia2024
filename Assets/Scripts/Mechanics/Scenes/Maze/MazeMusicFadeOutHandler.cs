using UnityEngine;
using System.Collections;

public class MazeMusicFadeOutHandler : InteractableObject, Entity
{
    InstantiateLoadingScreen sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        sceneLoader = FindObjectOfType<InstantiateLoadingScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    new public void Interact(Entity other)
    {
        if (other is Player)
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("MazeSoundtrack", 1f);
            sceneLoader.LoadNewScene("Bea's Room");
        }
    }
}

