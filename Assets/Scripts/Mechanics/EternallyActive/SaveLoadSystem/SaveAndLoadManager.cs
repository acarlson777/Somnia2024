using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAndLoadManager : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) 
             SaveCurrentScene();
    }

    public static void SaveCurrentScene()
    {
        print("Saving Scene!!!");
        PlayerPrefs.SetString("Last Scene", SceneManager.GetActiveScene().name);
    }
    public static void LoadSavedScene()
    {
        print("Loading Scene: " + PlayerPrefs.GetString("Last Scene", "Bea's Room"));
        InstantiateLoadingScreen.Instance.LoadNewScene(PlayerPrefs.GetString("Last Scene","Tutorial")); // will default to the 1th scene because 0th is main menu
    }
    public static void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ResetGame()
    {
        ResetGameData();
    }

    public static string GetSavedScene()
    {
        return PlayerPrefs.GetString("Last Scene", "Tutorial");
    }
}
