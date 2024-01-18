using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderPortraitAboveBox : MonoBehaviour
{

    [SerializeField] Image portrait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        portrait.transform.SetSiblingIndex(1);


    }
}
