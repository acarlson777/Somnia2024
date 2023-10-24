using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : AudioInteraction
{
    private GameObject audioCompiler;
    private AudioCompiler audioCompilerScript;
    public string[] songs;
    private int index;
    private AudioSource currentlyPlayingSong = null;

    public Soundtrack(GameObject caller)
    {
        audioCompiler = caller;
        audioCompilerScript = audioCompiler.GetComponent<AudioCompiler>();
    }

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
        foreach (SongInstance song in audioCompilerScript.songList)
        {
            if (song.name == name)
            {
                return song;
            }
        }
        throw new Exception("No song of name \"" + name + "\"");
    }
}
