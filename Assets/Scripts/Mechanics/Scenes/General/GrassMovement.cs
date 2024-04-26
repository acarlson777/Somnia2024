using UnityEngine;
using System.Collections;

public class GrassMovement : MonoBehaviour
{
    [Range(0, 180f)] public float rotationMinX;
    [Range(0, 180f)] public float rotationMaxX;
    [Range(0, 180f)] public float rotationMinY;
    [Range(0, 180f)] public float rotationMaxY;
    [Range(0, 180f)] public float rotationMinZ;
    [Range(0, 180f)] public float rotationMaxZ;
    [Range(0, 10f)] public float timeToTake;
    public float timeTaken = 0;
    private Vector3 minRot;
    private Vector3 maxRot;
    private Vector3 target;
    private bool isForth = false;

    private void Start()
    {
        minRot = new Vector3(rotationMinX, rotationMinY, rotationMinZ);
        maxRot = new Vector3(rotationMaxX, rotationMaxY, rotationMaxZ);
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(Vector3.Lerp(gameObject.transform.rotation.eulerAngles, target, timeTaken/timeToTake * Time.deltaTime)); //something wrong on this line
        timeTaken += Time.deltaTime;

        if (gameObject.transform.rotation.Equals(Quaternion.Euler(target)) || timeTaken > timeToTake)
        {
            isForth = !isForth;
            timeTaken = 0;

            if (isForth)
            {
                target = minRot;
            }
            else
            {
                target = maxRot;
            }
        }
    }
}
