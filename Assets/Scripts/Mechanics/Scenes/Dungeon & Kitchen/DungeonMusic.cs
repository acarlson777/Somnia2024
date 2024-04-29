using UnityEngine;
using System.Collections;

public class DungeonMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1) ;
        // plays drip every 4-5 seconds
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 5));
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("drip", gameObject);
            print("ttestey78rysei8yghszef");
        }
    }
}