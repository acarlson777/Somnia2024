using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonP : InteractableObject, Entity
{

  public Pistion pistion;


    new protected void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity){
      print("clicked button!");
      pistion.activate();
    }

}
