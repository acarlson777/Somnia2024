using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneInteractable : InteractableObject, Entity
{

  public string sceneName;
  public bool active;

  new protected void Start(){
    base.Start();
    this.gameObject.SetActive(active);
  }

  new public void Interact(Entity entity){

    InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);

  }
}
