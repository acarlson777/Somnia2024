using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public string type;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        if (type == "sfx")
        {
            slider.value = PlayerPrefs.GetFloat("sfxVolume",1);
        }
        else if (type == "song")
        {
            slider.value = PlayerPrefs.GetFloat("songVolume",1);
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
            PlayerPrefs.SetFloat("sfxVolume", slider.value);
        }
        else if (type == "song")
        {
            PlayerPrefs.SetFloat("songVolume", slider.value);
        }
    }
}
