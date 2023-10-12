using UnityEngine;
using System.Collections;

public static class AudioManager
{
    //Using a name, any sound can be played, stopped, faded in or faded out using the AudioManager

    public static void PlaySound(string name, GameObject caller)
    {
        Debug.Log("Sound Played");
        DictionaryOfSounds.soundsDictionary[name].Play(caller);
    }

    public static void PlayStop(string name)
    {
        DictionaryOfSounds.soundsDictionary[name].Stop();
    }

    public static void FadeIn(string name, GameObject caller, float seconds)
    {
        DictionaryOfSounds.soundsDictionary[name].FadeIn(seconds, caller);
    }

    public static void FadeOut(string name, float seconds)
    {
        DictionaryOfSounds.soundsDictionary[name].FadeOut(seconds);
    }
}
