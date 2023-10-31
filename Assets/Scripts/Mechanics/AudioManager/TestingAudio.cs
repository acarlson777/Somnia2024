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
            AudioManagerSingleton.Instance.Play("song3", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManagerSingleton.Instance.Stop("song3");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManagerSingleton.Instance.FadeIn("song3", 5, gameObject);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManagerSingleton.Instance.FadeOut("song3", 5);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManagerSingleton.Instance.Play("soundtrack1", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManagerSingleton.Instance.Stop("soundtrack1");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManagerSingleton.Instance.FadeIn("soundtrack1", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManagerSingleton.Instance.FadeOutAndStopSoundtrack("soundtrack1", 5);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("soundtrack1", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("soundtrack1", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("soundtrack1", gameObject);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrackOnce("soundtrack1", 5, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("NewAudioSystemOtherScene");
        }
    }
}