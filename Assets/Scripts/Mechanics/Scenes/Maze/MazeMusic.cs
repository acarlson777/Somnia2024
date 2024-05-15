using UnityEngine;
using System.Collections;

public class MazeMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("wind", 2, gameObject);
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(.001f);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("MazeSoundtrack", 1f, gameObject);
    }
}
