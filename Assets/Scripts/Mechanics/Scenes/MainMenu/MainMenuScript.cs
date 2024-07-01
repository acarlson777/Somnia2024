using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void GoToMainMenu()
    {
        InstantiateLoadingScreen.Instance.LoadNewScene("Main Menu");
        AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack(AudioManagerSingleton.currentSong, 1f);
    }
}
