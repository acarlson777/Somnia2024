using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogueClickthrough : MonoBehaviour
{
    bool sceneChanged = false;
    bool startedDialogue = false;

    [SerializeField] Image portrait;
    [SerializeField] Sprite[] portraits;
    [SerializeField] string[] names;
    [SerializeField] string[] Text;
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
        print("POP: " + Text[0]);
        DialogueManager.PopDialogue(Text);

    }

}
