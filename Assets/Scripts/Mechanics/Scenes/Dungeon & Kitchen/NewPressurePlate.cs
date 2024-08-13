using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPressurePlate : MonoBehaviour
{
    private int numberOfThingsOnPressurePlate = 0;
    [HideInInspector] public bool isPressed = false;
    [SerializeField] private Material glowOff;
    [SerializeField] private Material glowOn;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("PistonObject") || other.name.Equals("Bea")) && !other.isTrigger)
        {
            if (numberOfThingsOnPressurePlate == 0)
            {
                AudioManagerSingleton.Instance.Play("lever", gameObject);
            }
            numberOfThingsOnPressurePlate++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PistonObject") || other.name.Equals("Bea") && !other.isTrigger)
        {
            numberOfThingsOnPressurePlate--;
        }
    }

    private void Update()
    {
        isPressed = numberOfThingsOnPressurePlate > 0;
        if (isPressed)
        {
            gameObject.GetComponent<Renderer>().material = glowOn;
        } else
        {
            gameObject.GetComponent<Renderer>().material = glowOff;
        }
    }
}
