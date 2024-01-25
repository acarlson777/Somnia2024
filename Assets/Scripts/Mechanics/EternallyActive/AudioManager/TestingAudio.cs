using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestingAudio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManagerSingleton.Instance.Play("BeasTheme", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManagerSingleton.Instance.Stop("BeasTheme");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManagerSingleton.Instance.FadeIn("BeasTheme", 5, gameObject);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManagerSingleton.Instance.FadeOut("BeasTheme", 5);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManagerSingleton.Instance.Play("BeasRoom", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManagerSingleton.Instance.Stop("BeasRoom");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManagerSingleton.Instance.FadeIn("BeasRoom", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("BeasRoom", 5);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("BeasRoom", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("BeasRoom", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("BeasRoom", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrackOnce("BeasRoom", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("NewAudioSystemOtherScene");
        }
    }
}