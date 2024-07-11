using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> riggsList;
    private int riggsIndex = 0;

    public void switchToNextRiggs()
    {
        riggsList[riggsIndex].SetActive(false);
        riggsIndex++;
        riggsList[riggsIndex].SetActive(true);
    }
}
