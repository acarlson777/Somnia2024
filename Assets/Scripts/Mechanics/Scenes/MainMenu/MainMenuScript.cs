using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    InstantiateLoadingScreen sceneLoader;
    public string soundtrackToStop;
    public void Start()
    {
        sceneLoader = GetComponent<InstantiateLoadingScreen>();
    }

    public void GoToMainMenu()
    {
        AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack(soundtrackToStop, 1f);
        InstantiateLoadingScreen.Instance.LoadNewScene("Main Menu");
    }
}
