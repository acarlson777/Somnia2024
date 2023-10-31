using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/*
public static class RefactoredAudioManager
{
    public static void Play(string name, GameObject caller)
    {
        FindSoundOfName(name).Play(caller);
    }


    public static void Stop(string name)
    {
        FindSoundOfName(name).Stop();
    }


    public static void FadeIn(string name, float seconds, GameObject caller)
    {
        FindSoundOfName(name).FadeIn(seconds, caller);
    }


    public static void FadeOut(string name, float seconds)
    {
        FindSoundOfName(name).FadeOut(seconds);
    }

    
    private static AudioInteraction FindSoundOfName(string name)
    {
        foreach (AudioInteraction song in RefactoredAudioCompiler.allSounds)
        {
            if (name == song.Name)
            {
                return song;
            }
        }
        return null;
    }
}
*/