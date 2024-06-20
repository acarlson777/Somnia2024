using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// class to Load the next scene while calling fadescripts from FadeImage
public class SceneLoader : MonoBehaviour
{
    // cached references and script references
    public GameObject loadingScreen;

    Canvas loadingScreenCanvas;

    public string sceneToLoad;

    [HideInInspector] public bool fadeOut;
    [HideInInspector] public bool fadeIn = false;
    public int loadingScreenLength;
    public static bool fading;

    // scene load the second the Scene Loader game obejct is instantiated
    void Start()
    {
        loadingScreenCanvas = GameObject.Find("LoadingScreenCanvas").GetComponent<Canvas>();
        SceneLoad();
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    // on scene load, fade in the black screen then fade out once scene changes
    public void SceneLoad()
    {
        StartCoroutine(FadeInLoading());
        StartCoroutine(FadeOutLoading());
    }

    // fades in the loading screen when fadeIn = true, then loads the scene after waiting a second to give loading screen feel
    IEnumerator FadeInLoading()
    {
        fadeIn = true;
        yield return new WaitForSeconds(loadingScreenLength);
        fadeIn = false;
        SceneManager.LoadScene(sceneToLoad);
    }

    // after waiting a few seconds on black screen, fade back out and destroy gameobjects
    IEnumerator FadeOutLoading()
    {
        fading = true;
        fadeOut = true;
        yield return new WaitForSeconds(loadingScreenLength);
        fadeOut = false;
        yield return new WaitForSeconds(2);
        if (loadingScreenCanvas == null)
        {
            Debug.Log("Loading Screen Canvas does not exist, This may be because the previous scene did not properly make it!");
        }
        else
        {
            Destroy(loadingScreenCanvas.gameObject);
        }
        fading = false;
        Destroy(gameObject); // Destroy ourselves
    }
}
