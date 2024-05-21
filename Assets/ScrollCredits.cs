using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollCredits : MonoBehaviour
{
    //public TextMeshProUGUI[] creditsText;
    //public Canvas canvas;
    public float scrollSpeed = 1f;
    public float middlePosition = 0f;
    public float initialPause = 1f;
    bool isPaused = false;
    bool scrolling = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(scrollTheText());

    }

    IEnumerator scrollTheText()
    {
        yield return new WaitForSeconds(initialPause);
        while (scrolling)
        {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.1f);

            if (!isPaused && transform.position.y >= middlePosition)
            {
                isPaused = true;
                yield return new WaitForSeconds(3f);
                isPaused = false;
            }
            if (transform.position.y > 1000) scrolling = false;

        }
        yield return null;
    }
}
