using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAndLoadManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        SaveCurrentScene();
    }

    public static void SaveCurrentScene()
    {
        PlayerPrefs.SetString("Last Scene", SceneManager.GetActiveScene().name);
    }
    public static void LoadSavedScene()
    {
        InstantiateLoadingScreen.Instance.LoadNewScene(PlayerPrefs.GetString("Last Scene",SceneManager.GetSceneAt(0).name)); // will default to the 0th scene
    }
}
