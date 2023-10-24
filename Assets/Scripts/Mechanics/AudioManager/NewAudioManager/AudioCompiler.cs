using UnityEngine;
using System.Collections;

public class AudioCompiler : MonoBehaviour
{
    public SfxInstance[] sfxList;
    public SongInstance[] songList;
    public Soundtrack[] soundtrackList;

    void Start()
    {
        sfxList = StaticSoundLists.sfxList;
        songList = StaticSoundLists.songList;
        soundtrackList = StaticSoundLists.soundtrackList;

        AudioInteraction[] allSounds = new AudioInteraction[StaticSoundLists.songList.Length + StaticSoundLists.sfxList.Length + StaticSoundLists.soundtrackList.Length];
        StaticSoundLists.songList.CopyTo(allSounds, 0);
        StaticSoundLists.sfxList.CopyTo(allSounds, StaticSoundLists.songList.Length);
        StaticSoundLists.soundtrackList.CopyTo(allSounds, StaticSoundLists.sfxList.Length);
        StaticSoundLists.allSounds = allSounds;
    }

    void Update()
    {
        //Set Volume of All Sounds Here
    }
}
