using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public string type;
    // [SerializeField]  public Image handleImage;
    private Slider slider;
    [SerializeField]  public Sprite imageAboveThreshold;
    [SerializeField]  public Sprite imageBelowThreshold;

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

        // Subscribe to the OnValueChanged event of the slider
        slider.onValueChanged.AddListener(UpdateHandleImage);

        // Set the initial image based on the starting value of the slider
        UpdateHandleImage(slider.value);
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

    private void UpdateHandleImage(float value){

      Image handleImage = GetComponentInChildren<Image>();
      if (value < 0.2f)
        {
            // Set the image below the threshold
            handleImage.sprite = imageBelowThreshold;
        }
        else
        {
            // Set the image above or equal to the threshold
            handleImage.sprite = imageAboveThreshold;

        }
    }
}
