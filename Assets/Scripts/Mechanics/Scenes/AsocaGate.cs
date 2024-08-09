using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsocaGate : MonoBehaviour
{
    CharacterDialogue character;
    public GameObject gateObject;
    [SerializeField] float fadeTime;
    [SerializeField] float timeElapsed;
    private bool happened = false;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<CharacterDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.timesInteracted >= character.lines.Count)
        {
            if (GameObject.Find("CharacterDialogueBox") == null) {
                if (!happened)
                {
                    StartCoroutine(FadeOut());
                }
                happened = true;
            }

        }
    }

    IEnumerator FadeOut()
    {
        timeElapsed = 0;
        while (timeElapsed <= fadeTime)
        {
            Color color = gateObject.GetComponent<Renderer>().material.color;
            color.a = 1 - timeElapsed/fadeTime;
            gateObject.GetComponent<Renderer>().material.color = color;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gateObject.SetActive(false);
    }

}