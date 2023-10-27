using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{

    public TextMeshProUGUI startText;
    public float fadeSpeed = 1f;
    float waitSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTextInNOut());
    }

    // Update is called once per frame
    void Update()
    {
        
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
