using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollCredits : MonoBehaviour
{
    public List<TextMeshProUGUI> textyBoxies;
    public float moveSpeed = 100f;
    public float waitTime = 1f;
    public float delayTime;

    void Start()
    {
        StartCoroutine(ScrollTextBoxes());
    }

    private IEnumerator ScrollTextBoxes()
    {
        foreach (TextMeshProUGUI textBox in textyBoxies)
        {
            StartCoroutine(MoveNextTextBextWextShext(textBox));
            yield return new WaitForSeconds(delayTime);
        }
    }

    private IEnumerator MoveNextTextBextWextShext(TextMeshProUGUI textBox)
    {
        while (textBox.rectTransform.anchoredPosition.y < 50)
        {
            textBox.rectTransform.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);

        while (textBox.rectTransform.anchoredPosition.y < 1000)
        {
            textBox.rectTransform.anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
