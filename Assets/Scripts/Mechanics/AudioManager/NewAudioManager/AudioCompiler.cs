using UnityEngine;
using System.Collections;

public class AudioCompiler : MonoBehaviour
{
    public SfxInstance[] sfxList;
    public SongInstance[] songList;
    public Soundtrack[] soundtrackList;
    private SoundInteraction[] soundsList;
 
    void Start()
    {
        sfxList = StaticSoundLists.sfxList;
        songList = StaticSoundLists.songList;
        soundtrackList = StaticSoundLists.soundtrackList;


        soundsList = new SoundInteraction[StaticSoundLists.songList.Length + StaticSoundLists.sfxList.Length];
        StaticSoundLists.songList.CopyTo(soundsList, 0);
        StaticSoundLists.sfxList.CopyTo(soundsList, StaticSoundLists.songList.Length);


        AudioInteraction[] allSounds = new AudioInteraction[soundsList.Length + StaticSoundLists.soundtrackList.Length];
        soundsList.CopyTo(allSounds, 0);
        StaticSoundLists.soundtrackList.CopyTo(allSounds, soundsList.Length);
        StaticSoundLists.allSounds = allSounds;
    }

    void Update()
    {
        foreach (SoundInteraction soundInteraction in soundsList)
        {
            soundInteraction.SetVolume();
        }
    }
}
