using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
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

        PlayerPrefs.SetFloat("SongVolume",1f);
        PlayerPrefs.SetFloat("SfxVolume",1f);
    }

    void Update()
    {
        foreach (SoundInteraction soundInteraction in songsAndSfxs)
        {
            soundInteraction.SetVolume();
        }
    }


    //These are here because I need to access them in the Sound class but can't make them there because you can't StartCoRoutine without a Monobehaviour
    public IEnumerator FadeInRoutine(AudioInteraction audioInteraction, float seconds)
    {
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioInteraction.audioSource.volume = audioInteraction.GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator FadeOutRoutine(AudioInteraction audioInteraction, float seconds)
    {
        float totalTime = 0;
        while (totalTime < seconds)
        {
            audioInteraction.audioSource.volume = audioInteraction.GetVolume() - audioInteraction.GetVolume() * totalTime / seconds;

            totalTime += Time.deltaTime;
            yield return null;
        }
        audioInteraction.Stop();
    }
}
*/