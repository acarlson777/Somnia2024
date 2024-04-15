using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBarFixScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -2;
        Debug.Log("sorting");
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
    }
}
