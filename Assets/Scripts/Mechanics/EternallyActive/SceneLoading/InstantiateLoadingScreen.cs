using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

// class to instantiate all loadingScreen prefabs and load the scene
public class InstantiateLoadingScreen : MonoBehaviour
{

    public static InstantiateLoadingScreen Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            print("Destroying!");
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadingScreenPrefab = Resources.Load("LoadingScreen") as GameObject;
        sceneLoaderPrefab = Resources.Load("Scene Loader") as GameObject;
        loadingScreenCanvasPrefab = Resources.Load("LoadingScreenCanvas") as GameObject;
        print(loadingScreenCanvasPrefab);
    }

    // Cached references
    public GameObject loadingScreenCanvasPrefab;
    [HideInInspector] public GameObject loadingScreenPrefab;
    [HideInInspector] public GameObject sceneLoaderPrefab;

    Image loadingScreenImage;
    private Color originalImage;

    public void LoadNewScene(string newScene)
    {
        print(loadingScreenCanvasPrefab);
        GameObject loadingScreenCanvas = Instantiate(loadingScreenCanvasPrefab);
        loadingScreenCanvas.name = "LoadingScreenCanvas";

        print(loadingScreenPrefab);
        GameObject loadingScreen = Instantiate(loadingScreenPrefab, loadingScreenCanvas.transform);
        loadingScreen.name = "LoadingScreen";


        GameObject sceneLoader = Instantiate(sceneLoaderPrefab);
        sceneLoader.name = "Scene Loader";
        sceneLoader.GetComponent<SceneLoader>().sceneToLoad = newScene;

        loadingScreenImage = GameObject.Find("LoadingScreen").GetComponent<Image>();
        originalImage = loadingScreenImage.color;
        // sets loadingscreen opacity to zero to be able to fade in later
        loadingScreenImage.color = new Color(originalImage.r, originalImage.g, originalImage.b, 0);
    }
}
