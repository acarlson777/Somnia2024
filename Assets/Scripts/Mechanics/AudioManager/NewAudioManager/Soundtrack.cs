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

    public string[] songs;
    private int index;
    private AudioSource currentlyPlayingSong = null;

    public void Play(GameObject caller)
    {
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.Play(caller);
        currentlyPlayingSong = activeSong.audioSource;
        //Run NextSongLogic Coroutine
    }

    public void Stop()
    {
        FindSongOfName(songs[index]).Stop();
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        SongInstance activeSong = FindSongOfName(songs[index]);
        activeSong.FadeIn(seconds, caller);
        currentlyPlayingSong = activeSong.audioSource;
        //Run NextSongLogic Coroutine
    }

    public void FadeOut(float seconds)
    {
        FindSongOfName(songs[index]).FadeOut(seconds);
    }

    IEnumerator NextSongLogic()
    {
        //Wait until length of current song has almost elapsed then fadeout current song and update index and fadeIn method from this class
        yield return null;
    }

    private SongInstance FindSongOfName(string name)
    {
        foreach (SongInstance song in RefactoredAudioCompiler.staticSongList)
        {
            if (song.Name == name)
            {
                return song;
            }
        }
        return null;
    }
}
