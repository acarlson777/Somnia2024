using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamJournalPopupScript : MonoBehaviour
{
    public GameObject[] bookPages;
    private uint currPage; // NOT TECHNICALY A PAGE
    GameObject joystick;
    GameObject interact_button;
    // Start is called before the first frame update
    private void Awake()
    {
        joystick = GameObject.Find("Joystick");
        interact_button = GameObject.Find("InteractButton");
        joystick?.SetActive(false);
        interact_button?.SetActive(false);
    }
    void Start()
    {
        print("Created the Dream Journal PopUp");

    }
    private void RecalculatePages()
    {
        for (int i = 0; i < bookPages.Length;i++)
        {
            if (i / 2 == currPage)
            {
                bookPages[i].SetActive(true);
            }
            else
            {
                bookPages[i].SetActive(true);
            }
        }
    }

    public void NextPage()
    {
        currPage++;
        if (currPage == bookPages.Length) {
            currPage--;
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
        
    }
    void kms()
    {
        joystick?.SetActive(false);
        interact_button?.SetActive(false);
    }
}
