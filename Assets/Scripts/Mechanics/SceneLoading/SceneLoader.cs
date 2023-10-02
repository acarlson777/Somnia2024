using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);
        Invoke("SceneLoad", 3f); 
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    void SceneLoad()
    {
        SceneManager.LoadScene("SceneChange2");
        StartCoroutine(StartLoadingScreen());
    }

    IEnumerator StartLoadingScreen()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        loadingScreen.SetActive(false);
    }
}
