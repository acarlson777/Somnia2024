using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveOrActive : MonoBehaviour
{

    [HideInInspector] public List<GameObject> optimizableObjects;
    public Transform player;
    public float optimizeDistance = 20f;
    public bool optimizerActive = true;
    private float timer = 0f;
    public float activateTime = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > activateTime && optimizerActive)
        {
            foreach (GameObject optimizable in optimizableObjects)
            {
                float distanceFromPlayer = Vector3.Distance(optimizable.transform.position, player.transform.position);
                if (distanceFromPlayer > optimizeDistance)
                {
                    optimizable.SetActive(false);
                }
                else { optimizable.SetActive(true); }
            }
            timer = 0f;
        }
    }
}
