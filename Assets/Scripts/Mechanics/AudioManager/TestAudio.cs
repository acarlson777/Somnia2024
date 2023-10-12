using UnityEngine;
using System.Collections;

public class TestAudio : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AudioManager.FadeIn("boom" ,this.gameObject, 5);
            Debug.Log("Key Pressed");
        }
    }
}
