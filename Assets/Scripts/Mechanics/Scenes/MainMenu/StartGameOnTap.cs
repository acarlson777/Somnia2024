using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOnTap : MonoBehaviour
{
    InstantiateLoadingScreen loadingScreen;
    SettingsButtonScript settingsButton;
    string sceneToLoad = null;
    
    bool tapped = false;

    // Start is called before the first frame update
    void Start()
    {
        settingsButton = GameObject.Find("SettingsButtonButton").GetComponent<SettingsButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && !tapped)
        {
            AudioManagerSingleton.Instance.FadeOut("BeasTheme",1f);
            loadingScreen.LoadANewScene();
            tapped = true;
        }
        */
    }

    void OnMouseDown()
    {
        if (!tapped && !settingsButton.isOn && !SceneLoader.fading)
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("BeasThemeSoundtrack", 1f);
            SaveAndLoadManager.LoadSavedScene(); // if there is no saved scene then it defaults to main menu (build index 0)
            tapped = true;
        }
    }
    /*void startGame()
    {
        AudioManagerSingleton.Instance.FadeOut("BeasTheme", 1f);
        loadingScreen.LoadANewScene();
    }*/
}
