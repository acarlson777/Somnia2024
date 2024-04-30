using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialZoom : MonoBehaviour
{
    public float timeToTake;
    public float startZoom;
    private float endZoom;
    private float timeTaken = 0;
    public Camera camera;
    public float waitForStart;

    IEnumerator zoomOverTime()
    {
        yield return new WaitForSeconds(waitForStart);
        camera.orthographicSize = startZoom;
        while (timeTaken <= timeToTake)
        {
            camera.orthographicSize = startZoom - (Mathf.Sin(timeTaken / timeToTake * (Mathf.PI)/2) * (startZoom-endZoom));
            timeTaken += Time.deltaTime;
            yield return null;
        }
    }

    public void Start()
    {
        endZoom = camera.orthographicSize;
        StartCoroutine(zoomOverTime());
    }
}
