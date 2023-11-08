using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{

    private static DontDestroyUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
