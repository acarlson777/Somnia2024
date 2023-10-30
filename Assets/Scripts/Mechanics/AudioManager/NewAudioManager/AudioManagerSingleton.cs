using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagerSingleton : MonoBehaviour
{
    //SINGLETON CODE
    public static AudioManagerSingleton Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }



    //AUDIO MANAGER CODE
    public void Play(string name, GameObject caller)
    {
        Debug.Log("Playing " + name);
        FindSoundOfName(name).Play(caller);
    }

    public void PlayRandomSongFromSoundtrack(string name, GameObject caller)
    {
        Soundtrack soundtrack = (Soundtrack) FindSoundOfName(name);
        soundtrack.SetRandomSong();
        soundtrack.Play(caller);
    }

    public void Stop(string name)
    {
        Debug.Log("Stopping " + name);
        FindSoundOfName(name).Stop();
    }

    public void FadeIn(string name, float seconds, GameObject caller)
    {
        Debug.Log("Fading in " + name);
        FindSoundOfName(name).FadeIn(seconds, caller);
    }

    public void FadeInRandomSongFromSoundtrack(string name, float seconds, GameObject caller)
    {
        Soundtrack soundtrack = (Soundtrack) FindSoundOfName(name);
        soundtrack.SetRandomSong();
        soundtrack.FadeIn(seconds, caller);
    }

    public void FadeOut(string name, float seconds)
    {
        Debug.Log("Fading out " + name);
        FindSoundOfName(name).FadeOut(seconds);
    }

    public void FadeOutAndStopSoundtrack(string name, float seconds)
    {
        Debug.Log("Fading out and stopping " + name);
        Soundtrack soundtrack = (Soundtrack)FindSoundOfName(name);
        soundtrack.FadeOutAndStop(seconds);
    }

    private AudioInteraction FindSoundOfName(string name)
    {
        foreach (AudioInteraction song in allSounds)
        {
            if (name == song.Name)
            {
                return song;
            }
        }
        return null;
    }



    //AUDIO COMPILER CODE
    public List<SfxInstance> sfxList;
    public List<SongInstance> songList;
    public List<Soundtrack> soundtrackList;
    [HideInInspector] public List<AudioInteraction> allSounds = new List<AudioInteraction>();
    private List<SoundInteraction> songsAndSfxs = new List<SoundInteraction>();

    void Start()
    {
        allSounds.AddRange(sfxList);
        allSounds.AddRange(songList);
        allSounds.AddRange(soundtrackList);

        songsAndSfxs.AddRange(sfxList);
        songsAndSfxs.AddRange(songList);

        PlayerPrefs.SetFloat("SongVolume",1f); //TEMP LINES
        PlayerPrefs.SetFloat("SfxVolume",1f); //TEMP LINES
    }

    void Update()
    {
        foreach (SoundInteraction soundInteraction in songsAndSfxs)
        {
            if (!soundInteraction.IsVolumeFading) 
            { 
                soundInteraction.SetVolume();
            }
        }
    }
}