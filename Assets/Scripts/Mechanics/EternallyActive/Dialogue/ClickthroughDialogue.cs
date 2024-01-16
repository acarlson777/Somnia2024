using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickthroughDialogue : MonoBehaviour
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    bool sceneChanged = false;
    bool startedDialogue = false;


    public string sceneName;

    private void Start()
    {
        /*if (timesInteracted >= lines.Count)
        {
            timesInteracted = lines.Count - 1;
        }
        print("putting a dialogue" + timesInteracted);
        DialogueManager.PopDialogue(lines[timesInteracted].lines);
        timesInteracted++;*/
        StartCoroutine(StartClickThrough());
    }

    private void Update()
    {
        if (GameObject.Find("DialogueBox") == null && !sceneChanged && startedDialogue)
        {
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            sceneChanged = true;
        }
    }

    IEnumerator StartClickThrough()
    {
        yield return new WaitForSeconds(2f);
        startedDialogue = true;
        if (timesInteracted >= lines.Count)
        {
            timesInteracted = lines.Count - 1;
        }
        print("putting a dialogue" + timesInteracted);
        DialogueManager.PopDialogue(lines[timesInteracted].lines);
        timesInteracted++;

    }

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
