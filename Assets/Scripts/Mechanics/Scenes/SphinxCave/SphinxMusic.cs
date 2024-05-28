using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphinxMusic : MonoBehaviour
{
    // Use this for initialization
    public GameObject justANormalChild;
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("wind", 2, gameObject);
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        // plays drip every 4-5 seconds
        while (true)
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("water", gameObject);
            yield return new WaitForSeconds(Random.Range(4, 5));
        }
    }
}
