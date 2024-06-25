using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollCredits : MonoBehaviour
{
    public List<GameObject> textyBoxies;
    public float moveSpeed = 100f;
    public float waitTime = 1f;
    public float delayTime;
    public bool midGame;

    void Start()
    {
        StartCoroutine(ScrollTextBoxes());
    }

    private IEnumerator ScrollTextBoxes()
    {
        foreach (GameObject textBox in textyBoxies)
        {
            StartCoroutine(MoveNextTextBextWextShext(textBox));
            yield return new WaitForSeconds(delayTime);
        }

        if (midGame)
        {
            InstantiateLoadingScreen.Instance.LoadNewScene("S1 (Bea's Room 5)");
        }
    }

    private IEnumerator MoveNextTextBextWextShext(GameObject textBox)
    {
        while (textBox.GetComponent<RectTransform>().anchoredPosition.y < 50)
        {
            textBox.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);

        while (textBox.GetComponent<RectTransform>().anchoredPosition.y < 1000)
        {
            textBox.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
