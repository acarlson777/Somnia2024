using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumdropClickthrough : MonoBehaviour
{
    [SerializeField] private CharacterDialogueClickthrough characterDialogueClickthrough;
    [SerializeField] private GameObject gumdropTriggerCollider;
    private bool hasOccured = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gumdropTriggerCollider && !hasOccured)
        {
            characterDialogueClickthrough.gameObject.SetActive(true);
            characterDialogueClickthrough.Start();
            hasOccured = true;
        }
    }
}
