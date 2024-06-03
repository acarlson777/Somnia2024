using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreMooresNPC : InteractableObject, Entity
{

  public string soundsToPlay;

  [SerializeField]
  MoreMooreManager manager;
  bool hasFirefly = false;


    new protected void Start()
    {
        base.Start();
    }
    new public void Interact(Entity entity)
    {

        if (entity is Player)
        {

          if(!hasFirefly){

            // Get nums collected from manager.
            if(manager.give()){
              DialogueManager.PopDialogue(new string[] { "Thank you very much!" });
              hasFirefly = true;
            }else{
              DialogueManager.PopDialogue(new string[] { "You don't have enough dice to sell to me!!!" });
            }

          }else{
            DialogueManager.PopDialogue(new string[] { "You already gave it to me!!" });
          }






            //AudioManagerSingleton.PlayRandomOnce(this.gameObject);
            //Find soundtrack using string name then play random once
            // AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce(soundsToPlay, this.gameObject);

        }
    }


}
