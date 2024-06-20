using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonsManager : MonoBehaviour
{
    [SerializeField] private float secondsToWaitToShow;
    [SerializeField] private float secondsToTakeFadingIn;
    [SerializeField] private GameObject[] textBoxesToFadeIn;
    [SerializeField] private TextMeshProUGUI[] textToFadeIn;

    void Start()
    {
        if (SaveAndLoadManager.GetSavedScene() == "Tutorial")
        {
            Color currColor;
            foreach (TextMeshProUGUI text in textToFadeIn)
            {
                text.alpha = 0f;
            }
            foreach (GameObject button in textBoxesToFadeIn)
            {
                currColor = button.GetComponent<Image>().color;
                button.GetComponent<Image>().color = new Color(currColor.r, currColor.g, currColor.b, 0);
                button.SetActive(false);
            }
            StartCoroutine(WaitForTimeToFadeInAssets());
        } else
        {
            textToFadeIn[0].text = "Keep Dreaming";
        }
    }

    IEnumerator FadeInTextBox(GameObject button)
    {
        float timePassed = 0.0f;
        float alpha;
        while (secondsToTakeFadingIn > timePassed)
        {
            Color currColor = button.GetComponent<Image>().color;
            alpha = Mathf.Lerp(0, 1, timePassed / secondsToTakeFadingIn);
            Color nextColor = new Color(currColor.r, currColor.g, currColor.b, alpha);
            button.GetComponent<Image>().color = nextColor;
            timePassed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeInText(TextMeshProUGUI text)
    {
        float timePassed = 0.0f;
        while (secondsToTakeFadingIn > timePassed)
        {
            text.alpha = Mathf.Lerp(0, 1, timePassed / secondsToTakeFadingIn);
            timePassed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator WaitForTimeToFadeInAssets()
    {
        yield return new WaitForSeconds(secondsToWaitToShow);
        foreach (GameObject button in textBoxesToFadeIn)
        {
            button.SetActive(true);
            StartCoroutine(FadeInTextBox(button));
        }
        foreach (TextMeshProUGUI text in textToFadeIn)
        {
            StartCoroutine(FadeInText(text));
        }
    }
}
