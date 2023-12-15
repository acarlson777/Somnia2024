using UnityEngine;
using System.Collections;

public class SettingsButtonScript : MonoBehaviour
{
    [HideInInspector] public bool isOn = true;
    private GameObject settingsScreen;
    private GameObject joystick;
    private GameObject interactableButton;


    void Start()
    {
        settingsScreen = GameObject.Find("SettingsButtonScreen");
        try
        {
            joystick = GameObject.Find("Joystick");
            interactableButton = GameObject.Find("InteractButton");
        } catch { }
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
        try { 
        joystick.SetActive(!isOn);
        interactableButton.SetActive(!isOn);
        } catch { }
    }
}
