using UnityEngine;
using System.Collections;

public class MazeMusicFadeOutHandler : InteractableObject, Entity
{
    InstantiateLoadingScreen sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        sceneLoader = GetComponent<InstantiateLoadingScreen>();
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
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("Maze", 1);
            sceneLoader.LoadANewScene();
        }
    }
}

