using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetSceneAt(0).name != "Main Menu")
        {
            throw new System.Exception("Scene at index 0 must be main menu");
        }
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
        
        if (newScene == "Main Menu" && GetActiveSceneName() != newScene)
        {
            // we are loading from a random scene to the main menu
            SaveAndLoadManager.SaveCurrentScene();
        }
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
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
