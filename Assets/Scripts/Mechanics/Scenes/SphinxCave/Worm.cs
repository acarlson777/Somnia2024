using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private float timeToTake;
    [SerializeField] private float timeToTakeThisRun;
    [Range(0.0f,0.6f)] [SerializeField] private float randomness;
    [SerializeField] private float timeTaken = 0;

    void Start()
    {
        startPos = transform.localPosition;
        StartCoroutine(Move());
    }

    
    void Update()
    {

    }

    IEnumerator Move()
    {
        while (true)
        {
            timeToTakeThisRun = timeToTake * Random.Range(1 - randomness, 1 + randomness);
            while (timeTaken < timeToTakeThisRun)
            {
                transform.localPosition = Vector3.Lerp(startPos, endPos, timeTaken / timeToTakeThisRun);
                timeTaken += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = endPos;
            timeTaken = 0;

            Vector3 temp = startPos;
            startPos = endPos;
            endPos = temp;
        }
    }
}
