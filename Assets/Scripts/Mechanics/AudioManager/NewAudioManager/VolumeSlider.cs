using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public string type;
    private Slider slider;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();

        if (type == "sfx")
        {
            slider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else if (type == "song")
        {
            slider.value = PlayerPrefs.GetFloat("songVolume");
        }
        else
        {
            Debug.Log("Invalid Sound Type");
        }
    }

    // Update is called once per frame
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
