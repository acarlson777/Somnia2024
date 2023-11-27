using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizableObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SetInactiveOrActive>().optimizableObjects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
