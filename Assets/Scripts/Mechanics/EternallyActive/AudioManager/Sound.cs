using System;
using System.Collections;
using UnityEngine;

public interface SoundInteraction : AudioInteraction
{
    public void SetVolume();
    public float GetVolume();
    public bool IsVolumeFading 
    {
        get;
        set;
    }
}

public abstract class SoundInstance : SoundInteraction
{
    public string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    [HideInInspector]
    public bool _isVolumeFading = false;
    [HideInInspector]
    public bool IsVolumeFading 
    {
        get => _isVolumeFading;
        set => _isVolumeFading = value;
    }


    public float volume;
    public AudioClip audioClip;
    [HideInInspector] public AudioSource audioSource = null;

    public void Play(GameObject caller)
    {
        CreateSoundInstance(caller);

        audioSource.Play();
    }

    public void Stop()
    {
        if (audioSource == null) { throw new Exception("Attempt to stop audio that was never played"); }
        audioSource.Stop();
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        CreateSoundInstance(caller);

        audioSource.Play();
        AudioManagerSingleton.Instance.StartCoroutine(FadeInRoutine(seconds));
    }

    public IEnumerator FadeInRoutine(float seconds)
    {
        IsVolumeFading = true;
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioSource.volume = GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
        IsVolumeFading = false;
    }

    public void FadeOut(float seconds)
    {
        if (audioSource == null) { throw new Exception("Attempt to fade out audio that was never played"); }
        AudioManagerSingleton.Instance.StartCoroutine(FadeOutRoutine(seconds));
    }

    
    public IEnumerator FadeOutRoutine(float seconds)
    {
        IsVolumeFading = true;
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioSource.volume = GetVolume() - GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
        IsVolumeFading = false;
        Stop();
    }

    public abstract void SetVolume();
    public abstract float GetVolume();

    //Instead, check if the caller gameobject has the audioSource Attached to it already | if gameObject already has the audioSource, set the current audioSource to that source
    private void CreateSoundInstance(GameObject caller)
    {
        audioSource = caller.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = caller.AddComponent<AudioSource>();

        }
        ;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
    }
}


[System.Serializable]
public class SfxInstance : SoundInstance
{
    public override void SetVolume()
    {
        if (audioSource == null) { return; }
        audioSource.volume = volume * PlayerPrefs.GetFloat("sfxVolume");
    }

    public override float GetVolume()
    {
        return volume * PlayerPrefs.GetFloat("sfxVolume");
    }
}


[System.Serializable]
public class SongInstance : SoundInstance
{
    public override void SetVolume()
    {
        if (audioSource == null) { return; }
        audioSource.volume = volume * PlayerPrefs.GetFloat("songVolume");
    }

    public override float GetVolume()
    {
        return volume * PlayerPrefs.GetFloat("songVolume");
    }
}
