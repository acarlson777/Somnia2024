using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DreamJournalClickthrough : MonoBehaviour
{
    bool sceneChanged = true;
    public string sceneName;
    public string journalPopup;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartJournalClickthrough());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(journalPopup) == null && !sceneChanged)
        {
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            sceneChanged = true;
        }
    }

    IEnumerator StartJournalClickthrough()
    {
        yield return new WaitForSeconds(2f);
        PopupManager.CreatePopUp("ClickthroughDreamJournal");
        //dreamJournalPopup = gameObject.GetComponentInParent<DreamJournalPopupScript>();
        sceneChanged = false;


    }

}
