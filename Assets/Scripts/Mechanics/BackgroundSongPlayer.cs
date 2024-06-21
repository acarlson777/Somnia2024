using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSongPlayer : MonoBehaviour
{
    [SerializeField] private string soundTrackName;
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack(soundTrackName, 1f, gameObject);
    }
}
