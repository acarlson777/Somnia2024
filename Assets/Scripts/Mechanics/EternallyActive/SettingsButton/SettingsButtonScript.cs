using UnityEngine;
using System.Collections;

public class SettingsButtonScript : MonoBehaviour
{
    private bool isOn = true;
    private GameObject settingsScreen;
    private GameObject joystick;
    private GameObject interactableButton;


    void Start()
    {
        settingsScreen = GameObject.Find("SettingsButtonScreen");
        joystick = GameObject.Find("Joystick");
        interactableButton = GameObject.Find("InteractableButton");
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
        joystick.SetActive(!isOn);
        interactableButton.SetActive(!isOn);
    }
}
