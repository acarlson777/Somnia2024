using UnityEngine;
using System.Collections;

public class RandomWalkSprite : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenMovements;
    [SerializeField] private float maxTimeBetweenMovements;
    [SerializeField] private float moveStrength;
    private Rigidbody rb;
    private Vector3 lastForceAdded;
    public bool withinZone = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomMove());
    }

    public IEnumerator RandomMove()
    {
        while (withinZone)
        {
            Vector3 currentForceBeingAdded = new Vector3(Random.Range(-1.0f, 1.0f)*moveStrength, 0, Random.Range(-1.0f, 1.0f)*moveStrength);
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(currentForceBeingAdded);
            //print(currentForceBeingAdded);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenMovements,maxTimeBetweenMovements));
            lastForceAdded = currentForceBeingAdded;
        }
    }

    public IEnumerator ReturnMove()
    {
        while (!withinZone)
        {
            rb.AddForce(lastForceAdded * -1);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenMovements, maxTimeBetweenMovements));
        }
    }


}
