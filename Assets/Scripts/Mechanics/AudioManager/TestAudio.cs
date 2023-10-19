using UnityEngine;
using System.Collections;

public class TestAudio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.FadeInSound("boom" ,this.gameObject, 5);
            Debug.Log("Fade In");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.FadeOutSound("boom", 5);
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


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.FadeInSound("boom", this.gameObject, 5);
            Debug.Log("Fade In");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.FadeOutSound("boom", 5);
            Debug.Log("Fade Out");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManager.PlaySound("boom", this.gameObject);
            Debug.Log("Play Sound");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.StopSound("boom");
            Debug.Log("Stop Sound");
        }
    }
}
