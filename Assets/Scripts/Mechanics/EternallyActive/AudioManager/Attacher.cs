using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour
{
    // This class will be attached to random gameobjects.
    // The entire purpose for existance is to play a sound from an object and just stay there like a little parasite ;)
    // Start is called before the first frame update
    new public AudioInteraction audio;
    private AudioSource source;
    void Start()
    {
        GetComponent<AudioSource>();
    }
    Attacher Begin(AudioInteraction aSource)
    {
    
        return this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
