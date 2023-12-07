using UnityEngine;
using System.Collections;

public class ThroneRoomWallOpacity : MonoBehaviour
{
    public GameObject[] gameObjectsToMakeTransparent;
    private Coroutine currentCoroutine;
    public float transparencyTime;
    
    void Start()
    {

    }

    
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OpacityZone"))
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = StartCoroutine(MakeTransparent(transparencyTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OpacityZone"))
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = StartCoroutine(MakeOpaque(transparencyTime));
        }
    }

    IEnumerator MakeTransparent(float secs)
    {
        float time = 0;
        while (time <= secs)
        {
            foreach (GameObject gameObject in gameObjectsToMakeTransparent)
            {
                Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
                Color materialColor = gameObjectRenderer.material.color;
                materialColor.a = Mathf.Lerp(1, .5f, time / secs);
                gameObjectRenderer.material.color = materialColor;
            }
             
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MakeOpaque(float secs)
    {
        float time = 0;
        while (time <= secs)
        {
            foreach (GameObject gameObject in gameObjectsToMakeTransparent)
            {
                Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
                Color materialColor = gameObjectRenderer.material.color;
                materialColor.a = Mathf.Lerp(.5f, 1, time / secs);
                gameObjectRenderer.material.color = materialColor;
            }

            time += Time.deltaTime;
            yield return null;
        }
    }
}
