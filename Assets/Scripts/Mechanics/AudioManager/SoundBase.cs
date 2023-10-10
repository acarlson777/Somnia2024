using UnityEngine;
using System.Collections;


public interface Sound
{
    string name { get; set; }

    void Play();

    void Stop();

    void FadeIn(float seconds);

    void FadeOut(float seconds);

    void SetVolume();

    float GetVolume();

    void SetData(SoundBaseData soundBaseData);
}

public abstract class SoundBase : MonoBehaviour, Sound
{
    public float volume;
    public AudioClip audioClip;
    public bool loop;
    protected AudioSource audioSource;

    public abstract void SetVolume();

    public abstract float GetVolume();

    public void SetData(SoundBaseData soundBaseData)
    {
        name = soundBaseData.name;
        volume = soundBaseData.volume;
        audioClip = soundBaseData.audioClip;
        loop = soundBaseData.loop;
        audioSource.clip = audioClip;
    }

    public void Play()
    {
        SetVolume();
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void FadeIn(float seconds)
    {
        StartCoroutine(FadeOutRoutine(seconds));
    }
    
    public void FadeOut(float seconds)
    {
        StartCoroutine(FadeInRoutine(seconds));
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
    }
}

public class SFX : SoundBase
{
    public override void SetVolume()
    {
        audioSource.volume = volume * VolumeSliderValues.sfx;
    }

    public override float GetVolume()
    {
        return volume * VolumeSliderValues.sfx;
    }
}

public class Song : SoundBase
{
    public override void SetVolume()
    {
        audioSource.volume = volume * VolumeSliderValues.song;
    }

    public override float GetVolume()
    {
        return volume * VolumeSliderValues.song;
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