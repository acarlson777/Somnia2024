using UnityEngine;
using System.Collections;

public class RandomWalkSprite : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenMovements;
    [SerializeField] private float maxTimeBetweenMovements;
    [SerializeField] private float moveStrength;
    [SerializeField] private bool withinZone = true;
    [Range(0f, 100f)]
    [SerializeField] private float RETURN_CONSTANT;
    [SerializeField] private GameObject zone;
    private Rigidbody rb;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomMove());
        StartCoroutine(ReturnMove());
    }

    public IEnumerator RandomMove()
    {
        while (true)
        {
            while (withinZone)
            {
                Debug.Log("RANDOM WORKING");
                Vector3 currentForceBeingAdded = new Vector3(Random.Range(-1.0f, 1.0f) * moveStrength, 0, Random.Range(-1.0f, 1.0f) * moveStrength);
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(currentForceBeingAdded);
                yield return new WaitForSeconds(Random.Range(minTimeBetweenMovements, maxTimeBetweenMovements));
            }
            yield return null;
        }
    }

    public IEnumerator ReturnMove()
    {
        while (true)
        {
            while (!withinZone)
            {
                Debug.Log("RETURN WORKING");
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(Vector3.Normalize(zone.transform.position-transform.position) * RETURN_CONSTANT); ;
                yield return new WaitForSeconds(Random.Range(minTimeBetweenMovements, maxTimeBetweenMovements));
            }
            yield return null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(zone))
        {
            withinZone = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(zone))
        {
            withinZone = true;
        }
    }
}
