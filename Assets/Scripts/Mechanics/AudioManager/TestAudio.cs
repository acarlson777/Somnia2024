using UnityEngine;
using System.Collections;

public class TestAudio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.FadeIn("boom" ,this.gameObject, 5);
            Debug.Log("Fade In");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.FadeOut("boom", 5);
            Debug.Log("Fade Out");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.PlaySound("boom", this.gameObject);
            Debug.Log("Play Sound");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.StopSound("boom");
            Debug.Log("Stop Sound");
        }
    }
}
