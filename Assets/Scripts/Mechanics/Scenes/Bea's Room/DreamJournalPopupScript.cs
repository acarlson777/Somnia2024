using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamJournalPopupScript : MonoBehaviour
{
    public AudioClip StartSound;
    public AudioClip PageFlipSound;
    public GameObject[] bookPages;
    private int currPage; // NOT TECHNICALY A PAGE
    GameObject joystick;
    GameObject interact_button;
    GameObject settings_button;
    public bool debug = false;
    public AudioSource audioSource;

    
    // Start is called before the first frame update
    private void Awake()
    {
        joystick = GameObject.Find("Joystick");
        interact_button = GameObject.Find("InteractButton");
        settings_button = GameObject.Find("SettingsButton");
        joystick?.SetActive(false);
        interact_button?.SetActive(false);
        settings_button?.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }


    }
    void Start()
    {
        print("Created the Dream Journal PopUp");
        RecalculatePages();
        audioSource.clip = StartSound;
        audioSource.Play();
    }
    private void RecalculatePages()
    {
        audioSource.clip = PageFlipSound;
        audioSource.Play();
        for (int i = 0; i < bookPages.Length;i++)
        {
            
            if (i == currPage)
            {
                bookPages[i].SetActive(true);
            }
            else
            {
                bookPages[i].SetActive(false);

            }
        }
    }

    public void NextPage()
    {
        currPage++;

        if (currPage == bookPages.Length - 1)
        {
            BeasBedScript.noHostileMobsAround = true;
            
        }

        if (currPage == bookPages.Length) {
            //currPage--;
            Destroy(gameObject);
            return;
        }
        RecalculatePages();
    }
    public void PriorPage()
    {
        if (currPage != 0)
        {
            currPage--;
            RecalculatePages();
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (debug)
        {
            MobileLogic();
        }
        else
        {
            UnityEditorUpdate();
        }
#else
        MobileLogic();
#endif 
    }
    private void UnityEditorUpdate() { 
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width/2)
            {
                NextPage();
            }
            else
            {
                PriorPage();
            }
        }
            
    }
    private void MobileLogic()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                NextPage();
            }
            else
            {
                PriorPage();
            }
        }
    }
    private void OnDestroy()
    {
        joystick?.SetActive(true);
        interact_button?.SetActive(true);
        settings_button?.SetActive(true);
    }

}
