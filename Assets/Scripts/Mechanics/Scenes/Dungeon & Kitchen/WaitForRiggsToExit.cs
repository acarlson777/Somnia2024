using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForRiggsToExit : MonoBehaviour
{
    public PostPressurePlatesRiggsHandler postPressurePlatesRiggsHandler;
    public GameObject exit;


    // Update is called once per frame
    void Update()
    {
        if (postPressurePlatesRiggsHandler.shouldActivateExit)
        {
            exit.SetActive(true);
            enabled = false;
        }   
    }
}
