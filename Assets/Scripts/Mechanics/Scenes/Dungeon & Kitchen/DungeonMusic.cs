using UnityEngine;
using System.Collections;

public class DungeonMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("wind", 2, gameObject);
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1) ;
        // plays drip every 4-5 seconds
        while (true)
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("scraping", gameObject);
            yield return new WaitForSeconds(Random.Range(4, 5));
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("drip", gameObject);
            yield return new WaitForSeconds(Random.Range(4, 5));
        }
    }

}