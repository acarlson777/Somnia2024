using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("BeasThemeSoundtrack", 1f, gameObject);
    }
}
