using UnityEngine;
using System.Collections;

public class PointHandlingLight : MonoBehaviour
{
    public Light pointLight1;
    public Light pointLight2;

    public float outsideRange = 5.18f;
    public float bigSpaceRange = 10f;

    private Coroutine currentCoRoutine1;
    private Coroutine currentCoRoutine2;


    void Start()
    {
        
    }

    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightUpZone"))
        {
            if (currentCoRoutine1 != null)
            {
                StopCoroutine(currentCoRoutine1);
                StopCoroutine(currentCoRoutine2);
            }

            currentCoRoutine1 = StartCoroutine(GradientLightRangeMoveCoRoutine(pointLight1, bigSpaceRange, 2f));
            currentCoRoutine2 = StartCoroutine(GradientLightRangeMoveCoRoutine(pointLight2, bigSpaceRange, 2f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightUpZone"))
        {
            if (currentCoRoutine1 != null)
            {
                StopCoroutine(currentCoRoutine1);
                StopCoroutine(currentCoRoutine2);
            }

            StartCoroutine(GradientLightRangeMoveCoRoutine(pointLight1, outsideRange, 2f));
            StartCoroutine(GradientLightRangeMoveCoRoutine(pointLight2, outsideRange, 2f));
        }
    }

    IEnumerator GradientLightRangeMoveCoRoutine(Light light, float expectedNum, float secs) 
    {
        float time = 0;
        float startNum = light.range;
        while (time <= secs)
        {
            light.range = Mathf.Lerp(startNum, expectedNum, time / secs);
            time += Time.deltaTime;
            yield return null;
        }
        light.range = expectedNum;
    }
}
