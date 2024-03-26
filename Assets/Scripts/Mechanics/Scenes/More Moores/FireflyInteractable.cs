using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireflyInteractable : InteractableObject, Entity{

  [SerializeField]
  MoreMooreManager manager;

    new protected void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity)
    {

        if (entity is Player)
        {

          manager.collect();
          gameObject.active = false;

        }
    }
}
