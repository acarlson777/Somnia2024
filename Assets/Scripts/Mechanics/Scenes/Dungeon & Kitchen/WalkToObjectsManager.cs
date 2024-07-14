using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToObjectsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objectToWalkToList;
    [SerializeField] private FollowTarget followTarget;
    [SerializeField] private bool shouldGoInvisible;
    [SerializeField] private int objectIndex = 0;

    private void Start()
    {
        followTarget.Mark = objectToWalkToList[objectIndex];
    }

    private void Update()
    {
        if (followTarget._state == FollowTarget.State.TARGET_REACHED)
        {
            if (objectIndex < objectToWalkToList.Length) { objectIndex++; }

            if (objectIndex == objectToWalkToList.Length)
            {
                gameObject.SetActive(!shouldGoInvisible);
            }

            followTarget.Mark = objectToWalkToList[objectIndex];
        }
    }
}