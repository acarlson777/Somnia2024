using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

// class to instantiate all loadingScreen prefabs and load the scene
public class InstantiateLoadingScreen : MonoBehaviour
{
    // Cached references
    [HideInInspector] public GameObject loadingScreenCanvasPrefab;
    [HideInInspector] public GameObject loadingScreenPrefab;
    [HideInInspector] public GameObject sceneLoaderPrefab;

    // passes what scene to change to, can be changed via inspector per entity
    public string sceneToLoad = "SceneChange2";

    Image loadingScreenImage;
    private Color originalImage;

    private void Awake()
    {
        // cache references from assets folder
        loadingScreenPrefab = Resources.Load("LoadingScreen") as GameObject;
        sceneLoaderPrefab = Resources.Load("Scene Loader") as GameObject;
        loadingScreenCanvasPrefab = Resources.Load("LoadingScreenCanvas") as GameObject;
    }
    void Update()
    {
        //temporary condition, in the future, if player interacts with like a door or smth
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadANewScene();
        }
    }

    // Instantiates the loadingScreenCanvas, the loading screen, and the sceneloader which passes the sceneName to change to
    public void LoadANewScene()
    {
        GameObject loadingScreenCanvas = Instantiate(loadingScreenCanvasPrefab);
        loadingScreenCanvas.name = "LoadingScreenCanvas";

        GameObject loadingScreen = Instantiate(loadingScreenPrefab, loadingScreenCanvas.transform);
        loadingScreen.name = "LoadingScreen";

        GameObject sceneLoader = Instantiate(sceneLoaderPrefab);
        sceneLoader.name = "Scene Loader";
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = this.sceneToLoad;

        loadingScreenImage = GameObject.Find("LoadingScreen").GetComponent<Image>();
        originalImage = loadingScreenImage.color;
        // sets loadingscreen opacity to zero to be able to fade in later
        loadingScreenImage.color = new Color(originalImage.r, originalImage.g, originalImage.b, 0);
    }
}
