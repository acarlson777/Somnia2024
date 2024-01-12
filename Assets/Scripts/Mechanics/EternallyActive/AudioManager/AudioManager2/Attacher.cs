using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attachers : MonoBehaviour
{
    public float volume;
    public AudioClip audioClip;
    private AudioSource audioSource;
    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume * PlayerPrefs.GetFloat("songVolume");
        //audioSource.PlayOne

    }
}

