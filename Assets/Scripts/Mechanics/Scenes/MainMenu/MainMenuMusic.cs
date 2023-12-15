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
        AudioManagerSingleton.Instance.FadeIn("BeasRoom", 2f, gameObject);
    }
}
