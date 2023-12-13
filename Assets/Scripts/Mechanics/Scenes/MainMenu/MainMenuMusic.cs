using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        AudioManagerSingleton.Instance.Play("BeasTheme", gameObject);
    }
}
