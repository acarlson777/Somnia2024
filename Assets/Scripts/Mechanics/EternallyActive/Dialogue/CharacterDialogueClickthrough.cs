using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogueClickthrough : MonoBehaviour
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    bool sceneChanged = false;
    bool startedDialogue = false;

    [SerializeField] Image portrait;
    [SerializeField] Sprite[] portraits;
    [SerializeField] string[] names;
    //public TextMeshProUGUI nameText;
    [HideInInspector] public int lineNumber = 0;



    public string sceneName;

    private void Awake()
    {
        portrait.gameObject.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(StartClickThrough());
    }

    private void Update()
    {
        //nameText.text = names[lineNumber];
        if (portraits[lineNumber] == null) portrait.gameObject.SetActive(false);
        portrait.sprite = portraits[lineNumber];
        if (GameObject.Find("DialogueBox") == null && !sceneChanged && startedDialogue)
        {
            portrait.gameObject.SetActive(false);
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            sceneChanged = true;
        }
    }

    IEnumerator StartClickThrough()
    {
        yield return new WaitForSeconds(2f);
        portrait.gameObject.SetActive(true);
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
