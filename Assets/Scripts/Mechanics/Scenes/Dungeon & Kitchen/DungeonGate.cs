using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    public GameObject Bars;
    public GameObject firstMainPumpkid;
    public GameObject secondMainPumpkid;
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        CloseGate(); // Close the gate initially
    }

    public void OpenGate()
    {
        Bars.SetActive(false);
        
        if (firstMainPumpkid != null)
        {
            door.enabled = true;
            firstMainPumpkid.SetActive(false);
            secondMainPumpkid.SetActive(true);
        }

    }

    public void CloseGate()
    {
        //Bars.SetActive(true);
        if (firstMainPumpkid != null)
        {
            door.enabled = false;
            firstMainPumpkid.SetActive(true);
            secondMainPumpkid.SetActive(false);
        }
    }

  
}
