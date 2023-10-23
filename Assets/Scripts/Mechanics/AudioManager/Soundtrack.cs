using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soundtrack
{
    public List<Sound> allSounds = new List<Sound>();
    public int index;
    private bool active = false;
    public float fadeConst = 1f;
    private bool fading;
    private GameObject lastCaller;


    public void Play(GameObject caller)
    {
        active = true;
        lastCaller = caller;
        allSounds[index].Play(caller);
    }

    public void Stop()
    {
        active = false;
        allSounds[index].Stop();
    }

    public void FadeIn(float seconds, GameObject caller)
    {
        active = true;
        lastCaller = caller; 
        allSounds[index].FadeIn(seconds, caller);
    }

    public void FadeOut(float seconds)
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
            if (index >= allSounds.Count - 1)
            {
                index = -1;
            }
            else
            {
                index++;
                fading = false;
                allSounds[index].FadeIn(fadeConst, lastCaller);
            }
        }
    }

    public void SetVolume()
    {
        // This method does nothing
        Debug.Log("WARNING: RUNNING \"SetVolume\" METHOD ON SOUNDTRACK DOES NOTHING");
    }

    public float GetVolume()
    {
        // This method does nothing
        Debug.Log("WARNING: RUNNING \"GetVolume\" METHOD ON SOUNDTRACK DOES NOTHING");
        return -1;
    }
}
