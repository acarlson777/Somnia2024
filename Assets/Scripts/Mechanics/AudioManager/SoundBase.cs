﻿using UnityEngine;
using System.Collections;


public interface Sound
{
    public string soundName { get => soundName; set => soundName = value; }

    void Play(GameObject compiler);

    void Stop();

    void FadeIn(float seconds, GameObject compiler);

    void FadeOut(float seconds);

    void SetVolume();

    float GetVolume();

    void SetData(SoundBaseData soundBaseData);

    string GetName();

    void SetName(string name);
}

public abstract class SoundBase : MonoBehaviour, Sound
{
    public string soundName;

    public float volume;
    public AudioClip audioClip;
    public bool loop;
    protected AudioSource audioSource = null;


    public abstract void SetVolume();
    public abstract float GetVolume();

    public void SetData(SoundBaseData soundBaseData)
    {
        SetName(soundBaseData.name);
        volume = soundBaseData.volume;
        audioClip = soundBaseData.audioClip;
        loop = soundBaseData.loop;
    }

    protected void CreateAudioSource(GameObject caller)
    {
        audioSource = caller.AddComponent<AudioSource>();
        audioSource.loop = loop;
        audioSource.clip = audioClip;
    }

    public void Play(GameObject caller)
    {
        if (audioSource == null) { CreateAudioSource(caller); }
        SetVolume();
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        if (audioSource == null) { CreateAudioSource(caller); }
        audioSource.volume = 0;
        audioSource.Play();
        StartCoroutine(FadeInRoutine(seconds));
    }
    
    public void FadeOut(float seconds)
    {
        StartCoroutine(FadeOutRoutine(seconds));
    }

    IEnumerator FadeInRoutine(float seconds)
    {
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioSource.volume = GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOutRoutine(float seconds)
    {
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioSource.volume = GetVolume() - GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
        Stop();
    }

    public string GetName()
    {
        return soundName;
    }

    public void SetName(string soundName)
    {
        this.soundName = soundName;
    }
}

public class Sfx : SoundBase
{
    public override void SetVolume()
    {
        if (audioSource != null) { audioSource.volume = volume * VolumeSliderValues.sfxVolume; }
    }

    public override float GetVolume()
    {
        return volume * VolumeSliderValues.sfxVolume;
    }
}

public class Song : SoundBase
{
    public override void SetVolume()
    {
        if (audioSource != null) { audioSource.volume = volume * VolumeSliderValues.songVolume; }
    }

    public override float GetVolume()
    {
        return volume * VolumeSliderValues.songVolume;
    }
}

[System.Serializable]
public class SoundBaseData
{
    public string type;
    public string name;
    public float volume;
    public bool loop;
    public AudioClip audioClip;
}