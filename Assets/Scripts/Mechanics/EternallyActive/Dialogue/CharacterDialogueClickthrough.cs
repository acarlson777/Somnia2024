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
    [HideInInspector] public int lineNumber = 0;
    [HideInInspector] TextMeshProUGUI nameText;

    public string sceneName;

    private void Start()
    {
        StartCoroutine(StartClickThrough());
    }

    private void Update()
    {
        if (portrait != null)
        portrait.sprite = portraits[lineNumber];
        if (nameText != null) nameText.text = names[lineNumber];
        if (GameObject.Find("CharacterDialogueBox") == null && !sceneChanged && startedDialogue)
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
        CharacterDialogueManager.PopCharacterDialogue(lines[timesInteracted].lines);
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        portrait = GameObject.Find("Portraits").GetComponent<Image>();
        timesInteracted++;

    }

    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }
}
