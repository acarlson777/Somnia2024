using UnityEngine;
using System.Collections;

public class PointHandlingLight : MonoBehaviour
{
    public Light pointLight1;
    public Light pointLight2;

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
            pointLight1.intensity = 3.24f*2;
            pointLight2.intensity = 3.24f*2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LightUpZone"))
        {
            pointLight1.intensity = 3.24f;
            pointLight2.intensity = 3.24f;
        }
    }

    IEnumerator GradientFloatMoveCoRoutine(float num, float expectedNum, float secs) //Make it pass the variable by reference somehow
    {
        float startTime = 0;
        float startNum = num;
        while (startTime < secs)
        {
            num = Mathf.Lerp(startNum, expectedNum, startTime / secs);
            yield return null;
        }
    }
}
