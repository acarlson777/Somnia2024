using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{


    [SerializeField]
    public Material glowOff;
    public Material glowOn;
    private Material mat;
    private void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
  
    }


    public void startGlow(){

        //gameObject.GetComponent<Renderer>().material = glowOn;
        AudioManagerSingleton.Instance.Play("lever",gameObject);
        mat.SetColor(Shader.PropertyToID("_EmissionColor"), mat.color * 0.1f);


    }

    public void stopGlow(){

        mat.SetColor(Shader.PropertyToID("_EmissionColor"), Color.black);


    }



}
