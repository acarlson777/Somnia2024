using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{
    public List<Voicelines> lines;
    private int timesInteracted = 0;
    bool sceneChanged = false;
    bool startedDialogue = false;

    [SerializeField] Image portrait;
    [SerializeField] Sprite[] portraits;
    [SerializeField] string name;
    [HideInInspector] TextMeshProUGUI nameText;



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
        nameText.text = name;
        if (GameObject.Find("DialogueBox") == null && startedDialogue)
        {
            portrait.gameObject.SetActive(false);
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
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        timesInteracted++;

    }

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
