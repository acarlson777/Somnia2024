using UnityEngine;
using System.Collections;

public class SettingsButtonScript : MonoBehaviour
{
    private bool isOn = true;
    private GameObject settingsScreen;


    void Start()
    {
        settingsScreen = GameObject.Find("SettingsButtonScreen");
        Toggle();
        //Use settingsScreen gameObject to get the sliders and any other things (might not be necessary because the volume sliders handle themselves
    }

   
    void Update()
    {
        
    }


    public void Toggle()
    {
        isOn = !isOn;
        settingsScreen.SetActive(isOn);
    }
}
