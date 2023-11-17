using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void DestroyPopUP()
    {
        PopupManager.DestroyCurrentPopUp();
    }
    
}
