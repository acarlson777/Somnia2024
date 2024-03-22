using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForRiggsToExit : MonoBehaviour
{
    public ImprisonedRiggs imprisonedRiggs;
    public GameObject exit;
    void Start()
    {
        imprisonedRiggs = FindObjectOfType<ImprisonedRiggs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (imprisonedRiggs.exitIsActive)
        {
            exit.SetActive(true);
            enabled = false;
        }
        
    }
}
