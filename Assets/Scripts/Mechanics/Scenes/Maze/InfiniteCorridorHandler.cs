using UnityEngine;
using System.Collections;

public class InfiniteCorridorHandler : MonoBehaviour
{
    public GameObject corridorPrefab;
    public GameObject cubePrefab;
    public float distanceOfExpansion;
    private bool madeNextArea = false;
    GameObject parent;

    void Start()
    {
        parent = GameObject.Find("Empty");
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yofhajklsdbvhjnascbasdhjbgsdfjbilo/swd");
        if (!madeNextArea)
        {
            madeNextArea = true;
            Vector3 newTransformRight = (transform.right*distanceOfExpansion)+transform.position;
            newTransformRight.y = transform.position.y;

            Instantiate(corridorPrefab, newTransformRight, corridorPrefab.transform.rotation, corridorPrefab.transform);
        }
    }
}
