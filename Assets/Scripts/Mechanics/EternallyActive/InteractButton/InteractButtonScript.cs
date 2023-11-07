using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonScript : MonoBehaviour
{
    public Living entity;
    public void Interact()
    {
        entity.PressInteract();
    }

}
