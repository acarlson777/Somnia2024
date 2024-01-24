using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogueClickthrough : MonoBehaviour

{
    bool sceneChanged = false;
    bool startedDialogue = false;

    // Sore in an object to acceess throu Unitu Inspector -> convert to string[]
    [SerializeField]
    private List<TableRow> table = new List<TableRow>();

    Image portrait;
    //public TextMeshProUGUI nameText;
    [HideInInspector] public int lineNumber = 0;
    [HideInInspector] TextMeshProUGUI nameText;

    // Method to convert the list property to an array
    public T[] ConvertListToArray<T>(Func<TableRow, T> getProperty)
    {
        List<T> result = new List<T>();

        foreach (TableRow row in table)
        {
            result.Add(getProperty(row));
        }

        return result.ToArray();
    }



    public string sceneName;

    private void Start()
    {
        StartCoroutine(StartClickThrough());
    }

    private void Update()
    {

        Sprite[] portraits = ConvertListToArray(row => row.portrait);
        string[] names = ConvertListToArray(row => row.name);

        // if (portraits[lineNumber] == null) portrait.gameObject.SetActive(false);
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

        string[] Text = ConvertListToArray(row => row.text);
        yield return new WaitForSeconds(2f);

        startedDialogue = true;
        print("POP: " + Text[0]);
        CharacterDialogueManager.PopCharacterDialogue(Text);
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        portrait = GameObject.Find("Portraits").GetComponent<Image>();

    }


}


[System.Serializable]
public class TableRow {

  public Sprite portrait;
  public string name;
  public string text;
}