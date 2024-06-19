using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private SettingsButtonScript settingsButton;
    bool tapped = false;

    void Start()
    {
        settingsButton = GameObject.Find("SettingsButtonButton").GetComponent<SettingsButtonScript>();
    }

    public void OnClick()
    {
        if (tapped || settingsButton.isOn) return;

        if (!SceneLoader.fading)
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("BeasThemeSoundtrack", 1f); //This is jank because this script is currently only used for the main menu, sorry if anyone else is using this - Cai S.
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            tapped = true;
        }
    }
}
