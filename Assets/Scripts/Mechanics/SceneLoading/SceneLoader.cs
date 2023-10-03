using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;

    [HideInInspector] public bool fadeOut;
    [HideInInspector] public bool fadeIn = false;
    public int loadingScreenLength = 3;

    void Start()
    {
        //temporary test load scene, in the future just call sceneload
        Invoke("SceneLoad", 3); 
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    // on scene load, fade in the black screen then fade out once scene changes
    void SceneLoad()
    {
        StartCoroutine(FadeInLoading());
        StartCoroutine(FadeOutLoading());
    }

    IEnumerator FadeInLoading()
    {
        fadeIn = true;
        yield return new WaitForSeconds(2);
        fadeIn = false;
        SceneManager.LoadScene("SceneChange2");
    }


    IEnumerator FadeOutLoading()
    {
        fadeOut = true;
        yield return new WaitForSeconds(loadingScreenLength);
        fadeOut = false;
    }
}
