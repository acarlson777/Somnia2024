using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireFlyInteractable : InteractableObject, Entity{

  [SerializeField]
  public bool isCollected = false;

    new protected void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity)
    {

        if (entity is Player)
        {

        }
    }
}
