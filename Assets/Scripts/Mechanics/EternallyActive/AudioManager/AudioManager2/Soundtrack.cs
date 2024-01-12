using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Soundtrack : AudioInteraction
{
    public string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public float fadeTime;

    public string[] sounds;
    private int index = 0;
    private AudioSource currentlyPlayingSound = null;
    private Coroutine currentNextSoundLogicCoroutine = null;
    private GameObject lastCaller;
    private SoundInstance activeSound;


    public void Play(GameObject caller)
    {
        if (currentNextSoundLogicCoroutine != null) {AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine);}
        if (currentlyPlayingSound != null) {currentlyPlayingSound.Stop();}
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.Play(caller);
        currentlyPlayingSound = activeSound.audioSource;
        lastCaller = caller;
        currentNextSoundLogicCoroutine = AudioManagerSingleton.Instance.StartCoroutine(NextSoundLogic());
        Debug.Log("Soundtrack \"" + Name + "\" is playing" + " with song \"" + activeSound.Name + "\"");
    }

    public void PlayRandomOnce(GameObject caller)
    {
        if (currentNextSoundLogicCoroutine != null) { AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine); }
        if (currentlyPlayingSound != null) { currentlyPlayingSound.Stop(); }
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.Play(caller);
        currentlyPlayingSound = activeSound.audioSource;
        lastCaller = caller;
        Debug.Log("Soundtrack \"" + Name + "\" is randomly playing once" + " with song \"" + activeSound.Name + "\"");
    }

    public void FadeInRandomOnce(float seconds, GameObject caller)
    {
        if (currentNextSoundLogicCoroutine != null) { AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine); }
        if (currentlyPlayingSound != null) { currentlyPlayingSound.Stop(); }
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.FadeIn(seconds, caller);
        currentlyPlayingSound = activeSound.audioSource;
        lastCaller = caller;
        Debug.Log("Soundtrack \"" + Name + "\" is randomly fading in once" + " with song \"" + activeSound.Name + "\"");
    }

    public void Stop()
    {
        if (currentNextSoundLogicCoroutine != null){AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine);}
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.Stop();
        currentlyPlayingSound = null;
        currentNextSoundLogicCoroutine = null;
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        if (currentNextSoundLogicCoroutine != null) {AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine);}
        if (currentlyPlayingSound != null) {currentlyPlayingSound.Stop();}
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.FadeIn(seconds, caller);
        currentlyPlayingSound = activeSound.audioSource;
        lastCaller = caller;
        currentNextSoundLogicCoroutine = AudioManagerSingleton.Instance.StartCoroutine(NextSoundLogic());
        Debug.Log("Soundtrack \"" + Name + "\" is fading in" + " with song \"" + activeSound.Name + "\"");
    }

    public void FadeOut(float seconds)
    {
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.FadeOut(seconds);
        currentlyPlayingSound = null;
        currentNextSoundLogicCoroutine = null;
    }

    public void FadeOutAndStop(float seconds)
    {
        if (currentNextSoundLogicCoroutine != null){AudioManagerSingleton.Instance.StopCoroutine(currentNextSoundLogicCoroutine);}
        activeSound = FindSoundOfName(sounds[index]);
        activeSound.FadeOut(seconds);
        currentlyPlayingSound = null;
        currentNextSoundLogicCoroutine = null;
    }

    IEnumerator NextSoundLogic()
    {
        yield return new WaitForSeconds(currentlyPlayingSound.clip.length - fadeTime);
        FadeOut(fadeTime);
        index++;
        if (index >= sounds.Length)
        {
            index = 0;
        }
        yield return new WaitForSeconds(fadeTime);
        FadeIn(fadeTime, lastCaller);
    }

    public void SetRandomSong()
    {
        index = UnityEngine.Random.Range(0,sounds.Length-1);
    }

    private SoundInstance FindSoundOfName(string name)
    {
        foreach (SoundInstance sound in AudioManagerSingleton.Instance.songsAndSfxs)
        {
            if (sound.Name == name)
            {
                return sound;
            }
        }
        return null;
    }
}
