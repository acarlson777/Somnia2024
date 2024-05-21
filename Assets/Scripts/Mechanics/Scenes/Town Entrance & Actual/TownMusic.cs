using UnityEngine;
using System.Collections;

public class TownMusic : MonoBehaviour
{
    // Use this for initialization
    public GameObject justANormalChild;
    void Start() 
    {
        StartCoroutine(DelayedMusicPlay());
    }

    IEnumerator DelayedMusicPlay()
    {
        yield return new WaitForSeconds(1);
        AudioManagerSingleton.Instance.FadeInRandomSongFromSoundtrack("wind", 1f, gameObject);
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("commotion", justANormalChild);
        /* plays commotion foreva!!
        while (true)    
        {
            AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrack("commotion", gameObject);
            yield return new WaitForSeconds(26);    
        }*/
    }   
}