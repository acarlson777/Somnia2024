using UnityEngine;
using System.Collections;

public class Soundtrack : SoundBase, Sound
{
    public string soundName;
    public Sound[] allSounds;
    public int index;
    public bool active = true;


    void Play(GameObject caller)
    {
        allSounds[index].Play(caller);
    }

    void Update()
    {
        if (active)
        {
            if (allSounds[index].IsPlaying())
            {
                return;
            }
            if (index >= allSounds.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    void Stop()
    {
        active = false;
    }

    void FadeIn(float seconds, GameObject compiler)
    {

    }

    void FadeOut(float seconds)
    {

    }

    public override void SetVolume()
    {
        // This method does nothing
        Debug.Log("WARNING: RUNNING \"SetVolume\" METHOD ON SOUNDTRACK DOES NOTHING");
    }

    public override float GetVolume()
    {
        return volume * VolumeSliderValues.songVolume;
    }

    void SetData(Sound[] allSounds)
    {
        this.allSounds = allSounds;
    }
}
