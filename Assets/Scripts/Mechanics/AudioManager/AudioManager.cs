using UnityEngine;
using System.Collections;

public static class AudioManager
{
    //Using a name, any sound can be played, stopped, faded in or faded out using the AudioManager

    public static void PlaySound(string name)
    {
        DictionaryOfSounds.soundsDictionary[name].Play();
    }

    public static void PlayStop(string name)
    {
        DictionaryOfSounds.soundsDictionary[name].Stop();
    }

    public static void FadeIn(string name, float seconds)
    {
        DictionaryOfSounds.soundsDictionary[name].FadeIn(seconds);
    }

    public static void FadeOut(string name, float seconds)
    {
        DictionaryOfSounds.soundsDictionary[name].FadeOut(seconds);
    }
}
