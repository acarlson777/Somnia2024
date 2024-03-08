using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{


    [SerializeField]
    public Material glowOff;
    public Material glowOn;


    public void startGlow(){

      gameObject.GetComponent<Renderer>().material = glowOn;

    }

    public void stopGlow(){

      gameObject.GetComponent<Renderer>().material = glowOff;

    }



}
