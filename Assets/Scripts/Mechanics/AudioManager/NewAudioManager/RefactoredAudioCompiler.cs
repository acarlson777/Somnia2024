using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefactoredAudioCompiler : MonoBehaviour
{
    public List<SfxInstance> sfxList;
    public List<SongInstance> songList;
    public List<Soundtrack> soundtrackList;

    [HideInInspector] public static List<SfxInstance> staticSfxList;
    [HideInInspector] public static List<SongInstance> staticSongList;
    [HideInInspector] public static List<Soundtrack> staticSoundtrackList;
    [HideInInspector] public static List<AudioInteraction> allSounds = new List<AudioInteraction>();
    private List<SoundInteraction> songsAndSfxs = new List<SoundInteraction>();

    void Start()
    {
        staticSfxList = sfxList;
        staticSongList = songList;
        staticSoundtrackList = soundtrackList;

        allSounds.AddRange(sfxList);
        allSounds.AddRange(songList);
        allSounds.AddRange(soundtrackList);


        songsAndSfxs.AddRange(sfxList);
        songsAndSfxs.AddRange(songList);
    }

    void Update()
    {
        foreach (SoundInteraction soundInteraction in songsAndSfxs)
        {
            soundInteraction.SetVolume();
        }
    }
}
