using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Living, Entity
{
    private FocusArrowScript arrowScript;
    public AudioClip WalkingSound;
    private AudioSource audioSource;
    public enum SoundState
    {
        WALKING,
        STOPPED,
        STARTING,
        STOPPING,
    }
    public SoundState currentState;

    void Awake()
    {
        
        arrowScript =  gameObject.AddComponent<FocusArrowScript>();
        entityMaxSpeed = 4.2f;
        K_friction = 20f; // should be roufly 5 times the entity max Speed to not get an "ice floor" effect
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = WalkingSound;
        audioSource.loop = true;
        audioSource.volume = 0;
        audioSource.Play();
    
    }
    new void Start()
    {
        if (debug) print("Starting at Player");

        base.Start();
        
    }
    new private void Update()
    {
        base.Update();
        bool stopped = Mathf.Abs(rb.velocity.x) <= 0.001 && Mathf.Abs(rb.velocity.z) <= 0.001;
        float targetVolume = stopped ? -2 : 1;
        float targetFinalVolume = targetVolume * AudioManagerSingleton.getSFXVolume();
        float dif = targetFinalVolume - audioSource.volume;
        audioSource.volume = Mathf.Clamp01(audioSource.volume + dif * (1 - Mathf.Exp(-Time.deltaTime)));

    }

    // Update is called once per frame
    new public void FixedUpdate()
    {
        if (!JoystickInput.atRest())
        {
            vel = JoystickInput.worldOrientedJoystickDirection * speed;
        }
        base.FixedUpdate();

#if UNITY_EDITOR
        if( brain == null)
        {
            brain = new(this);
        }
#endif
        brain.SetSeen(gameobjectsTouching);
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (brain.GetClosestEntity() != null)
            {
                brain.GetClosestEntity().Interact(this);
            }
            else
            {
                print("No entity to interact with!");
            }
        }   
        
        arrowScript.SetFocus(brain.GetClosestEntityAsGO());
    }


    new public void Interact(Entity entity)
    {
        base.Interact(this);
    }
}
