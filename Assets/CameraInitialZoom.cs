using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialZoom : MonoBehaviour
{
    public float timeToTake;
    public float startZoom;
    public float endZoom;
    private float timeTaken = 0;
    public Camera camera;

    IEnumerator zoomOverTime()
    {
        camera.orthographicSize = startZoom;
        while (timeTaken <= timeToTake)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, endZoom, timeTaken / timeToTake);
            timeTaken += Time.deltaTime;
            yield return null;
        }
    }

    public void Start()
    {
        StartCoroutine(zoomOverTime());
    }
}
