using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class RefactoredAudioManager
{
    public static void Play(string name, GameObject caller)
    {
        FindSoundOfName(name);//.Play(caller);
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
        Debug.Log(StaticSoundLists.allSounds[0].name);
        /*
        foreach (AudioInteraction sound in StaticSoundLists.allSounds)
        {
            if (sound.name == name)
            {
                return sound;
            }
        }
        return null;
        */
        return null;
    }
}
