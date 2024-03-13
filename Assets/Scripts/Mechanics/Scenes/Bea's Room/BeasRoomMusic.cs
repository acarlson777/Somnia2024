﻿using UnityEngine;
using System.Collections;

public class BeasRoomMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("BeasRoom", 1f, gameObject);
        while (true) {
        yield return new WaitForSeconds(Random.Range(7,15));
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("creaksound 1", gameObject);
        yield return new WaitForSeconds(Random.Range(7,15));
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("creaksound 2", gameObject);
      }

    }
}
