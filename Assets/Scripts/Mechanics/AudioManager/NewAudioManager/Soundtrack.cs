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

    public string[] songs;
    private int index = 0;
    private AudioSource currentlyPlayingSong = null;
    private Coroutine currentNextSongLogicCoroutine = null;
    private GameObject lastCaller;
    

    public void Play(GameObject caller)
    {
        if (currentNextSongLogicCoroutine != null) {AudioManagerSingleton.Instance.StopCoroutine(currentNextSongLogicCoroutine);}
        if (currentlyPlayingSong != null) {currentlyPlayingSong.Stop();}
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.Play(caller);
        currentlyPlayingSong = activeSong.audioSource;
        lastCaller = caller;
        currentNextSongLogicCoroutine = AudioManagerSingleton.Instance.StartCoroutine(NextSongLogic());
        Debug.Log("Soundtrack \"" + Name + "\" is playing" + " with song \"" + activeSong.Name + "\"");
    }

    public void Stop()
    {
        AudioManagerSingleton.Instance.StopCoroutine(currentNextSongLogicCoroutine);
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.Stop();
        currentlyPlayingSong = null;
        currentNextSongLogicCoroutine = null;
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        if (currentNextSongLogicCoroutine != null) {AudioManagerSingleton.Instance.StopCoroutine(currentNextSongLogicCoroutine);}
        if (currentlyPlayingSong != null) {currentlyPlayingSong.Stop();}
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.FadeIn(seconds, caller);
        currentlyPlayingSong = activeSong.audioSource;
        lastCaller = caller;
        currentNextSongLogicCoroutine = AudioManagerSingleton.Instance.StartCoroutine(NextSongLogic());
        Debug.Log("Soundtrack \"" + Name + "\" is fading in" + " with song \"" + activeSong.Name + "\"");
    }

    public void FadeOut(float seconds)
    {
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.FadeOut(seconds);
        currentlyPlayingSong = null;
        currentNextSongLogicCoroutine = null;
    }

    public void FadeOutAndStop(float seconds)
    {
        AudioManagerSingleton.Instance.StopCoroutine(currentNextSongLogicCoroutine);
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.FadeOut(seconds);
        currentlyPlayingSong = null;
        currentNextSongLogicCoroutine = null;
    }

    IEnumerator NextSongLogic()
    {
        //Wait until length of current song has almost elapsed then fadeout current song and update index and fadeIn method from this class
        yield return new WaitForSeconds(currentlyPlayingSong.clip.length - fadeTime);
        FadeOut(fadeTime);
        index++;
        if (index >= songs.Length)
        {
            index = 0;
        }
        yield return new WaitForSeconds(fadeTime);
        FadeIn(fadeTime, lastCaller);
    }

    public void SetRandomSong()
    {
        index = UnityEngine.Random.Range(0,songs.Length-1);
    }

    private SongInstance FindSongOfName(string name)
    {
        foreach (SongInstance song in AudioManagerSingleton.Instance.songList)
        {
            if (song.Name == name)
            {
                return song;
            }
        }
        return null;
    }
}
