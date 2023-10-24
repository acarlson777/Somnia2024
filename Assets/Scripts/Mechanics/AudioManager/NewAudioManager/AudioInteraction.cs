using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AudioInteraction
{
    public string name { get => name; set => name = value; }
    public void Play(GameObject caller);
    public void Stop();
    public void FadeIn(float seconds, GameObject caller);
    public void FadeOut(float seconds);
}
