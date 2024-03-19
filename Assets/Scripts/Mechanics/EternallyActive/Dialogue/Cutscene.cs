using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{

    public string sceneName;
    [SerializeField] VideoPlayer video;
    RawImage image;

    private void Awake()
    {
        image = FindObjectOfType<RawImage>();
    }

    // Start is called before the first frame update
    void Start()
    {

        image.gameObject.SetActive(false);
        StartCoroutine(StartCutscene());
        video.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {
             

        
    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(1);
        image.gameObject.SetActive(true);
        video.Play();

    }

    void LoadScene(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("video ended");
        InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
    }
}
