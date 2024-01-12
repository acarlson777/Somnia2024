using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AudioInteraction2
{
    string Name
    {
        get;
        set;
    }
    public void Play(GameObject caller);
    public void Stop();
    public void FadeIn(float seconds, GameObject caller);
    public void FadeOut(float seconds);
}
