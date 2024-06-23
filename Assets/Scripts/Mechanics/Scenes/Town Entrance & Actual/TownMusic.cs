﻿using UnityEngine;
using System.Collections;

public class TownMusic : MonoBehaviour
{
    // Use this for initialization
    public GameObject justANormalChild;
    IEnumerator coroutine = null;
    void Start() 
    {
        if (justANormalChild == null)
        {
            justANormalChild = Instantiate(gameObject);
        }
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("wind", 1f, gameObject);
        //coroutine = DelayedMusicPlay();
        //StartCoroutine(coroutine);
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("commotionSoundTrack", justANormalChild);
        /* plays commotion foreva!!
        while (true)    
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("commotion", gameObject);
            yield return new WaitForSeconds(26);    
        }*/
        StopCoroutine(coroutine);
    }   
}