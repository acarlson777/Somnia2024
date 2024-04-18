using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    public GameObject Bars;
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        CloseGate(); // Close the gate initially
    }

    public void OpenGate()
    {

        door.enabled = true;
        Bars.SetActive(false);
    }

    public void CloseGate()
    {

        Bars.SetActive(true);
        door.enabled = false;
    }

  
}
