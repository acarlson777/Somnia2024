using UnityEngine;
using System.Collections;

public class RoomWallOpacity : MonoBehaviour
{
    public GameObject[] gameObjectsToMakeTransparent;
    private Coroutine currentCoroutine;
    public float transparencyTime;
    public float endTransparency;
    
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
        Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
        float time = 0;
        yield return null;
        float currentTransparency = gameObjectRenderer.material.color.a;
        while (time <= secs)
        {
            foreach (GameObject gameObject in gameObjectsToMakeTransparent)
            {
                Color materialColor = gameObjectRenderer.material.color;
                materialColor.a = Mathf.Lerp(currentTransparency, endTransparency, time / secs);
                gameObjectRenderer.material.color = materialColor;
            }
             
            time += Time.deltaTime;
            yield return null;
        }
        currentCoroutine = null;
    }

    IEnumerator MakeOpaque(float secs)
    {
        Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();
        float time = 0;
        yield return null;
        float currentTransparency = gameObjectRenderer.material.color.a;
        while (time <= secs)
        {
            foreach (GameObject gameObject in gameObjectsToMakeTransparent)
            {
                Color materialColor = gameObjectRenderer.material.color;
                materialColor.a = Mathf.Lerp(currentTransparency, 1, time / secs);
                gameObjectRenderer.material.color = materialColor;
            }

            time += Time.deltaTime;
            yield return null;
        }
        currentCoroutine = null;
    }
}
