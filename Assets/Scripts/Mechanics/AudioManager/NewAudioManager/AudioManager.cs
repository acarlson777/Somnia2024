using UnityEngine;
using System.Collections;
using System;

public static class AudioManager
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
        foreach (AudioInteraction sound in StaticSoundLists.allSounds)
        {
            if (sound.name == name)
            {
                return sound;
            }
        }
        return null;
    }
}
