using UnityEngine;
using System.Collections;

public class MazeMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(.001f);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("MazeSoundtrack", 1f, gameObject);
    }
}
