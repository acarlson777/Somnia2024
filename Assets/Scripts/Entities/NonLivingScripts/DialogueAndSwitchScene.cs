using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAndSwitchScene : GeneralInteractable, Entity
{
    public string SceneToSwitchTo;
    // Start is called before the first frame update
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (timesInteracted == lines.Count)
            {
                //we are done
                InstantiateLoadingScreen.Instance.LoadNewScene(SceneToSwitchTo);
            }
            else
            {
                print("putting a dialogue" + timesInteracted);
                DialogueManager.PopDialogue(lines[timesInteracted].lines);
                timesInteracted++;
            }
        }
    }
}
