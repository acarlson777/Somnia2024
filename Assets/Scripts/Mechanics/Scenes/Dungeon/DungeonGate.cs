using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CloseGate(); // Close the gate initially
    }

    public void OpenGate()
    {
        gameObject.SetActive(false);
    }

    public void CloseGate()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
