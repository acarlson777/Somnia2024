using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{

    public TextMeshProUGUI startText;
    public float fadeSpeed = 1f;
    float waitSpeed = 12.5f;
    public float startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //StartCoroutine(FadeTextIn());
    }

    // Update is called once per frame
    void Update()
    {
        startText.alpha = 2.5f * Mathf.Max(Mathf.Abs(Mathf.Sin(Mathf.PI * (Time.time - startTime) / 90f))- .41f, 0f);
        print(Time.time - startTime);

    }

    IEnumerator FadeTextIn()
    {
        while (true)
        {
            startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, 0);
            yield return new WaitForSeconds(waitSpeed);
            for (float i = 0; i < fadeSpeed; i += Time.deltaTime)
            {
                float opacity = Mathf.Lerp(0f, 1f, i / fadeSpeed);
                startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, opacity);
                yield return null;
            }
            yield return new WaitForSeconds(64f);

            for (float i = 0; i < fadeSpeed; i += Time.deltaTime)
            {
                float opacity = Mathf.Lerp(1f, 0f, i / fadeSpeed);
                startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, opacity);
                yield return null;
            }
            yield return new WaitForSeconds(waitSpeed);
        }
    }

    IEnumerator FadeTextInNOut()
    {
        while (true)
        {
            // Fade in the text
            for (float i = 0; i < fadeSpeed; i += Time.deltaTime)
            {
                float opacity = Mathf.Lerp(0f, 1f, i / fadeSpeed);
                startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, opacity);
                yield return null;
            }

            yield return new WaitForSeconds(1.0f);

            // Fade out the text
            for (float i = 0; i < fadeSpeed; i += Time.deltaTime)
            {
                float opacity = Mathf.Lerp(1f, 0f, i / fadeSpeed);
                startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, opacity);
                yield return null;
            }

            yield return new WaitForSeconds(waitSpeed);
        }
    }

}
