using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioCompiler : MonoBehaviour
{
    //Collects audios (both SFX and Songs) and sets their loopness and volumes (to the audioClip) on start while also setting AudioManagers sound list to the list of sounds afterwards
    public List<Sound> sounds = new List<Sound>();
    public Dictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();

    void Start()
    {
        //Make a public dictionary with name : class for all sounds
        foreach (Sound sound in sounds)
        {
            soundsDictionary[sound.name] = sound;
        }
    }

    
    void Update()
    {

    }
}
