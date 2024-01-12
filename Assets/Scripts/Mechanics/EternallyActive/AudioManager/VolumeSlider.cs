using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public string type;
    private Slider slider;
    private bool defaultRun;
    private int sliderCount;

    void Start()
    {
        slider = GetComponent<Slider>();
        defaultRun = PlayerPrefs.GetInt("DefaultRun", 0) == 0;
        slider.value = 0;

        if (defaultRun)
        {
            slider.value = 1;
            PlayerPrefs.SetInt("DefaultRun", 0);
        }

        else
        {

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
    }

    void Update()
    {
        if (!defaultRun)
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
}
