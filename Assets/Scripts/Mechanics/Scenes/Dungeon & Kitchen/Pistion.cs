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
  public Vector3 endDistance = new Vector3(0.0f, 0.0f, 0.0f);
  private float timer = 0;
  private bool timerReached = false;
    public PressurePlate correspondingPlate;
    // Start is called before the first frame update
    void Start()
    {
      startPos = transform.position;
      endPos = startPos + endDistance;
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
      if (correspondingPlate != null && correspondingPlate.isOccupied) { return; }
      activated = true;

      // timerReached = false;

    }



}
