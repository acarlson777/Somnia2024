using UnityEngine;
using System.Collections;

public class Door : InteractableObject, Entity
{
    [SerializeField] private AudioClip audioClip;
    public string sceneName;
    public string[] disabledText;

    new public void Interact(Entity other)
    {
        if (!enabled)
        {
            print(DialogueManager.PopDialogue(disabledText));
            return;
        }
        
        if (other is Player)
        {
            //GetComponent<AudioSource>()?.PlayOneShot(audioClip);
            if (audioClip != null)
            {
                GetComponent<AudioSource>().PlayOneShot(audioClip);
            }

            if (gameObject.GetComponent<SceneClickThrough>() == null)
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            else { gameObject.GetComponent<SceneClickThrough>().StartClickThrough(); }
        }
    }
}