using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreMooreManager : MonoBehaviour

{

  public int total = 0;
  public int gave = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void collected(){

    }

    public void collect(){
      total++;
    }

    public bool give(){
      if(total > 0){
        gave++;
        total--;

        if(gave == 8){
          // DO TRANSITION
          InstantiateLoadingScreen.Instance.LoadNewScene("CS8 (Whale Mouth)");
        }

        return true;
      }

      return false;
    }
}
