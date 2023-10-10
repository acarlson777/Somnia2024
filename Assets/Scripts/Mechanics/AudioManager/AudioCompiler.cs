using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioCompiler : MonoBehaviour
{
    //Collects audios (both SFX and Songs) and sets their loopness and volumes (to the audioClip) on start while also setting AudioManagers sound list to the list of sounds afterwards
    public SoundBaseData[] soundBaseDatas;
    public List<Sound> sounds;
    public Dictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();

    void Start()
    {
        foreach (SoundBaseData sound in soundBaseDatas)
        {
            if (sound.type == "sfx")
            {
                SFX sfx = new SFX();
                sfx.SetData(sound);
                sounds.Add(sfx);
            }
            else if (sound.type == "song")
            {
                Song song = new Song();
                song.SetData(sound);
                sounds.Add(song);
            }

            soundsDictionary[sound.name] = sounds[sounds.Count-1];
        }

        DictionaryOfSounds.soundsDictionary = soundsDictionary;
    }
}
