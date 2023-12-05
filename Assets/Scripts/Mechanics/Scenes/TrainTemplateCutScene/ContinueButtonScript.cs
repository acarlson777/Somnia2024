using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonScript : MonoBehaviour
{
    public float waitTime;
    public float fadeTime;
    private Image image;
    InstantiateLoadingScreen loadingScreen;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        loadingScreen = GetComponent<InstantiateLoadingScreen>();
        Color tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;
        StartCoroutine(WaitForContinue());
    }

    IEnumerator WaitForContinue()
    {
        float totalTime = 0;
        while (totalTime < waitTime)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float totalTime = 0;
        Color tempColor;
        while (totalTime < fadeTime)
        {
            tempColor = image.color;
            tempColor.a = Mathf.Lerp(0,1,totalTime/fadeTime);
            image.color = tempColor;
            totalTime += Time.deltaTime;
            yield return null;
        }
        tempColor = image.color;
        tempColor.a = 1;
        image.color = tempColor;
    }

    public void OnClick()
    {
        loadingScreen.LoadANewScene();
    }
}
