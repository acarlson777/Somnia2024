using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSliderLogic : MonoBehaviour
{
    public string type;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        VolumeSliderValues.sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        VolumeSliderValues.songVolume = PlayerPrefs.GetFloat("songVolume");

        if (type == "sfx")
        {
            slider.value = VolumeSliderValues.sfxVolume;
        }
        else if (type == "song")
        {
            slider.value = VolumeSliderValues.songVolume;
        }
        else
        {
            Debug.Log("Invalid Sound Type");
        }
    }
    
    void Update()
    {
        if (type == "sfx")
        {
            VolumeSliderValues.sfxVolume = slider.value;
            PlayerPrefs.SetFloat("sfxVolume", VolumeSliderValues.sfxVolume);
        }
        else if (type == "song")
        {
            VolumeSliderValues.songVolume = slider.value;
            PlayerPrefs.SetFloat("songVolume", VolumeSliderValues.songVolume);
        }
        else
        {
            Debug.Log("Invalid Sound Type");
        }

        //Debug.Log(DictionaryOfSounds.soundsDictionary);

        foreach (string soundName in DictionaryOfSounds.soundsDictionary.Keys)
        {
            DictionaryOfSounds.soundsDictionary[soundName].SetVolume();
        }
    }
}
