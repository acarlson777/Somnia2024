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
            Debug.Log("Fade In Sound");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.FadeOutSound("boom", 5);
            Debug.Log("Fade Out Sound");
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
            AudioManager.FadeInSoundtrack("theUltimateSounds", this.gameObject, 5);
            Debug.Log("Fade In Soundtrack");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.FadeOutSoundtrack("theUltimateSounds", 5);
            Debug.Log("Fade Out Soundtrack");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManager.PlaySoundtrack("theUltimateSounds", this.gameObject);
            Debug.Log("Play Soundtrack");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.StopSoundtrack("theUltimateSounds");
            Debug.Log("Stop Soundtrack");
        }
    }
}
