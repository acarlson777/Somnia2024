using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class InstantiateLoadingScreen : MonoBehaviour
{
    public GameObject loadingScreenCanvasPrefab;
    public GameObject loadingScreenPrefab;
    public GameObject sceneLoaderPrefab;

    Image loadingScreenImage;
    private Color originalImage;

    private void Awake()
    {
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

    void LoadANewScene()
    {
        GameObject loadingScreenCanvas = Instantiate(loadingScreenCanvasPrefab);
        loadingScreenCanvas.name = "LoadingScreenCanvas";

        GameObject loadingScreen = Instantiate(loadingScreenPrefab, loadingScreenCanvas.transform);
        loadingScreen.name = "LoadingScreen";

        GameObject sceneLoader = Instantiate(sceneLoaderPrefab);
        sceneLoader.name = "Scene Loader";

        loadingScreenImage = GameObject.Find("LoadingScreen").GetComponent<Image>();
        originalImage = loadingScreenImage.color;
        loadingScreenImage.color = new Color(originalImage.r, originalImage.g, originalImage.b, 0);
    }
}
