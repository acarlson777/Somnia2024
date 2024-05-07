using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForRiggsToExit : MonoBehaviour
{
    public ImprisonedRiggs character;
    public GameObject exit;


    // Update is called once per frame
    void Update()
    {
        if (character.exitIsActive)
        {
            exit.SetActive(true);
            enabled = false;
        }
        
    }
}
