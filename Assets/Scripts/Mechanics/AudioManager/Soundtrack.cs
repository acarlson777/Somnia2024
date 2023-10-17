using UnityEngine;
using System.Collections;

public class Soundtrack : SoundBase, Sound
{
    public string soundName;
    public Sound[] allSounds;
    public int index;
    private bool active = false;
    public float fadeConst = 1f;
    private bool fading;


    public new void Play(GameObject caller)
    {
        active = true;
        allSounds[index].Play(caller);
    }

    public new void Stop()
    {
        active = false;
        allSounds[index].Stop();
    }

    public new void FadeIn(float seconds, GameObject caller)
    {
        active = true;
        allSounds[index].FadeIn(seconds, caller);
    }

    public new void FadeOut(float seconds)
    {
        active = false;
        allSounds[index].FadeOut(seconds);
    }

    void Update()
    {
        if (active)
        {
            if (allSounds[index].IsPlaying())
            {
                //Check if allSounds[index] is fadeConst seconds from reaching end. if so, begin fadeout
                if (allSounds[index].audioClip.length - allSounds[index].audioSource.time <= fadeConst && fading == false)
                {
                    fading = true;
                    allSounds[index].FadeOut(fadeConst);
                }
                return;
            }
            if (index >= allSounds.Length - 1)
            {
                index = -1;
            }
            else
            {
                index++;
                fading = false;
                allSounds[index].FadeIn(fadeConst, this.gameObject);
            }
        }
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
