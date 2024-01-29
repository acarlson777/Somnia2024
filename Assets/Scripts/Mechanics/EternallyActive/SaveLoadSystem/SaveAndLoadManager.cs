using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAndLoadManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        if (InstantiateLoadingScreen.GetActiveSceneName() != InstantiateLoadingScreen.mainMenuName)
            SaveCurrentScene();
    }

    public static void SaveCurrentScene()
    {
        PlayerPrefs.SetString("Last Scene", SceneManager.GetActiveScene().name);
    }
    public static void LoadSavedScene()
    {
        InstantiateLoadingScreen.Instance.LoadNewScene(PlayerPrefs.GetString("Last Scene",SceneManager.GetSceneAt(1).name)); // will default to the 1th scene               because 0th is main menu
    }
    public static void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ResetGame()
    {
        ResetGameData();
    }
}
