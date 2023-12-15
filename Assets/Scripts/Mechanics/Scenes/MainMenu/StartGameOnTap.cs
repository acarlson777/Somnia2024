using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOnTap : MonoBehaviour
{
    InstantiateLoadingScreen loadingScreen;
    bool tapped = false;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !tapped)
        {
            AudioManagerSingleton.Instance.FadeOut("BeasTheme",1f);
            loadingScreen.LoadANewScene();
            tapped = true;
        }
    }
}
