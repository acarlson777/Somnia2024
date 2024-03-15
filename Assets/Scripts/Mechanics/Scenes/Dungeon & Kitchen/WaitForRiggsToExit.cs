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
        exit.SetActive(imprisonedRiggs.exitIsActive);
    }
}
