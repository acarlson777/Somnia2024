using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroneMusic : MonoBehaviour
{
    // Use this for initialization
    public GameObject justANormalChild;
    void Start()
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return null;
        while (true)
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce("bell", gameObject);
            yield return new WaitForSeconds(Random.Range(14, 30));

        }
    }
}
