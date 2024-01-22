using UnityEngine;
using System.Collections;

public class PointHandlingLight : MonoBehaviour
{
    public Light pointLight1;
    public Light pointLight2;

    public float outsideRange = 5.18f;
    public float bigSpaceRange = 10f;

    private Coroutine currentCoRoutine;





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightUpZone"))
        {

            if (currentCoRoutine != null)
            {
                StopCoroutine(currentCoRoutine);

            }
            currentCoRoutine = StartCoroutine(GradientLightRangeMoveCoRoutine( bigSpaceRange, 4f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightUpZone"))
        {
            if (currentCoRoutine != null)
            {
                StopCoroutine(currentCoRoutine);
            }

            currentCoRoutine = StartCoroutine(GradientLightRangeMoveCoRoutine(outsideRange, 2f));
        }
    }

    IEnumerator GradientLightRangeMoveCoRoutine(float expectedNum, float secs) 
    {
        float time = 0;
        float startNum = pointLight1.range;
        yield return null; // when the coroutine is started it should not immideatly change the value of light and instead wait for the next frame
        while (time <= secs)
        {
            float range = Mathf.Lerp(startNum, expectedNum, time / secs);
            pointLight1.range = range;
            pointLight2.range = range;
            time += Time.deltaTime;
            yield return null;
        }
        pointLight1.range = expectedNum;
        pointLight2.range = expectedNum;
        currentCoRoutine = null; //when we are done we just lose the reference

    }
}
