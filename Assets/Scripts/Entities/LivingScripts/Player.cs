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
        audioSource.Play();
        audioSource.Pause();
        StartCoroutine(Walking());
    }
    new void Start()
    {
        if (debug) print("Starting at Player");

        base.Start();
        
    }
    
    IEnumerator Walking()
    {
        yield return null; // NO clue why this line is necessary but if you delete it the while (true) loop wont work. DO NOT DELETE 
        while (true)
        {
            switch (currentState)
            {
                case SoundState.WALKING:
                    if (rb.velocity.x == 0 && rb.velocity.z == 0)
                    {
                        currentState = SoundState.STOPPING;
                    }
                    break;
                case SoundState.STOPPED:
                    if (rb.velocity.x != 0 || rb.velocity.z != 0)
                    {
                        currentState = SoundState.STARTING;
                    }
                    break;
                case SoundState.STARTING:
                    audioSource.UnPause();
                    currentState = SoundState.WALKING;
                    break;
                case SoundState.STOPPING:
                    audioSource.Pause();
                    currentState = SoundState.STOPPED;
                    break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
        if (!JoystickInput.atRest())
        {
            vel = JoystickInput.worldOrientedJoystickDirection * speed * Time.deltaTime;
        }
        if (vel.sqrMagnitude > entityMaxSpeed*entityMaxSpeed) // Can be optimized
        {
            vel *= entityMaxSpeed / vel.magnitude; // Set the magnitude to maxSpeed
        }
        // Overwrite the y axis so it doesn't count towards the magnitude
        vel.y = 0;
        // Apply Horizontal Friction
        
        if (vel.magnitude < K_friction * Time.deltaTime)
        {
            vel.x = 0;
            vel.z = 0;
        }
        else
        {
            Vector3 friction = vel.normalized * -K_friction * Time.deltaTime;
            vel += friction;
        }
        
        vel.y = rb.velocity.y;
        rb.velocity = vel;
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
