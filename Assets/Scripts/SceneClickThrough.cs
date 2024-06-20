using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneClickThrough : MonoBehaviour

{
    bool sceneChanged = false;
    bool startedDialogue = false;

    // Sore in an object to acceess throu Unitu Inspector -> convert to string[]
    [SerializeField]
    private List<CharTableRow> table = new List<CharTableRow>();

    Image portrait;
    //public TextMeshProUGUI nameText;
    [HideInInspector] public int lineNumber = 0;
    [HideInInspector] TextMeshProUGUI nameText;

    private AudioSource audioSource;

    [HideInInspector] public AudioClip[] voiceAudio;


    // Method to convert the list property to an array
    public T[] ConvertListToArray<T>(Func<CharTableRow, T> getProperty)
    {
        List<T> result = new List<T>();

        foreach (CharTableRow row in table)
        {
            result.Add(getProperty(row));
        }

        return result.ToArray();
    }



    public string sceneName;

    private void Start()
    {
        //StartCoroutine(StartClickThrough());
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    private void Update()
    {

        Sprite[] portraits = ConvertListToArray(row => row.charPortrait);
        string[] names = ConvertListToArray(row => row.charName);
        voiceAudio = ConvertListToArray(row => row.charVoiceLine);
        if (portrait != null)
        {
            if (portraits[lineNumber] == null)
                portrait.color = new Color(portrait.color.r, portrait.color.g, portrait.color.b, 0);
            else 
                portrait.color = new Color(portrait.color.r, portrait.color.g, portrait.color.b, 1);
            portrait.sprite = portraits[lineNumber];
            nameText.text = names[lineNumber];
        }

        if (GameObject.Find("CharacterDialogueBox") == null && !sceneChanged && startedDialogue)
        {
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            sceneChanged = true;
        }
    }

    public void StartClickThrough()
    {
        string[] Text = ConvertListToArray(row => row.charText);
        startedDialogue = true;
        audioSource.clip = voiceAudio[0];
        audioSource.Play();
        print("POP: " + Text[0]);
        CharacterDialogueManager.PopCharacterDialogue(Text);
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        portrait = GameObject.Find("Portraits").GetComponent<Image>();

    }


}


[System.Serializable]
public class CharTableRow
{

    public Sprite charPortrait;
    public string charName;
    public string charText;
    public AudioClip charVoiceLine;
}
