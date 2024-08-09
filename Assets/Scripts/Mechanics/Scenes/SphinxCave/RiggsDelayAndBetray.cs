using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggsDelayAndBetray : MonoBehaviour
{
    [SerializeField] private CharacterDialogue characterDialogue;
    [SerializeField] private GameObject followRiggs;
    [SerializeField] private GameObject walkToBeaRiggs;
    private bool hasActivated = false;
    private bool hasEnded = false;

    void Update()
    {
        if (characterDialogue.timesInteracted >= 7 && !hasActivated)
        {
            Vector3 followRiggsTransform = followRiggs.transform.position;
            followRiggs.SetActive(false);
            walkToBeaRiggs.transform.position = followRiggsTransform;
            followRiggs.SetActive(true);
            hasActivated = true;
        } else if (characterDialogue.timesInteracted >= 10 && !hasEnded)
        {
            AudioManagerSingleton.Instance.FadeIn("whale", 1, gameObject);
            InstantiateLoadingScreen.Instance.LoadNewScene("S1 (3rd Bea's Room)");
            hasEnded = true;
        }
    }
}
