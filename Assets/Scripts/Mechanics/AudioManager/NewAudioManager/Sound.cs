using System;
using UnityEngine;

public interface SoundInteraction : AudioInteraction
{
    public void SetVolume();
}

public abstract class SoundInstance : SoundInteraction
{
    public string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public float volume;
    public AudioClip audioClip;
    [HideInInspector] public AudioSource audioSource = null;

    public void Play(GameObject caller)
    {
        if (audioSource == null) { CreateSoundInstance(caller); }
        audioSource.Play();
    }

    public void Stop()
    {
        if (audioSource == null) { throw new Exception("Attempt to stop audio that was never played"); }
        audioSource.Stop();
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        if (audioSource == null) { CreateSoundInstance(caller); }
        //FadeIn Coroutine
    }

    public void FadeOut(float seconds)
    {
        if (audioSource == null) { throw new Exception("Attempt to fade out audio that was never played"); }
        //FadeOut Coroutine
    }

    public abstract void SetVolume();

    private void CreateSoundInstance(GameObject caller)
    {
        audioSource = caller.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
    }
}


[System.Serializable]
public class SfxInstance : SoundInstance
{
    public override void SetVolume()
    {
        volume *= PlayerPrefs.GetFloat("SfxVolume");
    }
}


[System.Serializable]
public class SongInstance : SoundInstance
{
    public override void SetVolume()
    {
        volume *= PlayerPrefs.GetFloat("SongVolume");
    }
}
