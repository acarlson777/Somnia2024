using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioCompiler : MonoBehaviour
{
    //Collects audios (both SFX and Songs) and sets their loopness and volumes (to the audioClip) on start while also setting AudioManagers sound list to the list of sounds afterwards
    public SoundBaseData[] soundBaseDatas;
    public List<Sound> sounds = new List<Sound>();
    public Dictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();

    void Start()
    {
        foreach (SoundBaseData sound in soundBaseDatas)
        {
            if (sound.type == "sfx")
            {
                Sfx sfx = gameObject.AddComponent<Sfx>();
                sfx.SetData(sound);
                sounds.Add(sfx);
            }
            else if (sound.type == "song")
            {
                Song song = gameObject.AddComponent<Song>();
                song.SetData(sound);
                sounds.Add(song);
            }
            else
            {
                Debug.Log("Sound Without Type");
            }

            soundsDictionary[sound.name] = sounds[sounds.Count-1];
        }

        DictionaryOfSounds.soundsDictionary = soundsDictionary;
    }
}
