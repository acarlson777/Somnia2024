using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistion : MonoBehaviour
{

  [SerializeField]
  private bool activated = false;
  private Vector3 startPos;
  private Vector3 endPos;
  public float speed;
  public float endDistance = -0.5f;
  private float timer = 0;
  private bool timerReached = false;
    // Start is called before the first frame update
    void Start()
    {

      startPos = transform.position;
      endPos = new Vector3(startPos.x + endDistance, startPos.y, startPos.z);

    }

    // Update is called once per frame
    void Update(){

      // if (timer <= 1){
      //   timer += Time.deltaTime;
      // }else{
      //
      //   Debug.Log("Done waiting");
      //   activated = false;
      //   //Set to false so that We don't run this again
      //   // timerReached = true;
      //   timer = 0;
      // }

      if (activated){

          transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);

          if (timer <= 1){
            timer += Time.deltaTime;
          }else{

            Debug.Log("Done waiting");
            activated = false;
            //Set to false so that We don't run this again
            // timerReached = true;
            timer = 0;
          }

      }else{

          transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
      }


    }

    public void activate(){
      //Wait for 5 seconds
      print("TURNED ON");
      activated = true;
      // timerReached = false;

    }



}
