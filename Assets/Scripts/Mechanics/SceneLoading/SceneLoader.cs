using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// class to Load the next scene while calling fadescripts from FadeImage
public class SceneLoader : MonoBehaviour
{

    private static SceneLoader instance;

    // cached references and script references
    public GameObject loadingScreen;

    Canvas loadingScreenCanvas;

    public string sceneToLoad;

    [HideInInspector] public bool fadeOut;
    [HideInInspector] public bool fadeIn = false;
    public int loadingScreenLength;

    public bool loading = false;

    private void Awake()
    {

    }

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
        fadeOut = true;
        yield return new WaitForSeconds(loadingScreenLength);
        fadeOut = false;
        yield return new WaitForSeconds(loadingScreenLength);
        Destroy(loadingScreenCanvas.gameObject);
        Destroy(gameObject);
    }
}
