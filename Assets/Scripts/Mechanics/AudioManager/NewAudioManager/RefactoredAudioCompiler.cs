using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefactoredAudioCompiler : MonoBehaviour
{
    public List<SfxInstance> sfxList = new List<SfxInstance>();
    public List<SongInstance> songList = new List<SongInstance>();
    public List<Soundtrack> soundtrackList = new List<Soundtrack>();
    private List<AudioInteraction> allSounds = new List<AudioInteraction>();
    private List<SoundInteraction> songsAndSfxs = new List<SoundInteraction>();

    void Start()
    {
        StaticSoundLists.sfxList.AddRange(sfxList);
        StaticSoundLists.songList.AddRange(songList); 
        StaticSoundLists.soundtrackList.AddRange(soundtrackList); 

        //SOMETHING TO DO WITH ACCESSING STATIC LIST IS CRASHING UNITY
        //MIGHT BE BECAUSE OF THE TYPECASTING GOING ON BELOW
        allSounds.AddRange(sfxList);
        allSounds.AddRange(songList);
        allSounds.AddRange(soundtrackList);
        StaticSoundLists.allSounds = allSounds;

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

    void PrintList()
    {
        foreach(AudioInteraction sfxInstance in sfxList)
        {
            Debug.Log(sfxInstance);
        }
    }
}
