using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{

    public string sceneName;
    [SerializeField] VideoPlayer video;
    private float initialVolume;
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
        initialVolume = video.GetDirectAudioVolume(0);
    }

    // Update is called once per frame
    void Update()
    {
        video.SetDirectAudioVolume(0, initialVolume * PlayerPrefs.GetFloat("sfxVolume"));
    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(.9f);
        image.gameObject.SetActive(true);
        video.Play();

    }

    void LoadScene(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("video ended");
        InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);

    }
   
}
