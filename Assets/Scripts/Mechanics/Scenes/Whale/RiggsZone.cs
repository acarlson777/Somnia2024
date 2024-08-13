using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggsZone : MonoBehaviour
{
    public CharacterDialogue characterDialogue;
    public GameObject bea;
    private bool interactedWith = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(bea) && !interactedWith)
        {
            characterDialogue.Interact(new Player());
            interactedWith = true;
            print("happened");
        }
    }
}
