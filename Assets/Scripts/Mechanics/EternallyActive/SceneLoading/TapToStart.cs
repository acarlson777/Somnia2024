using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{

    InstantiateLoadingScreen loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            loadingScreen.LoadNewScene("Bea's Room");
        }
    }
}
