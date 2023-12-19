using UnityEngine;
using System.Collections;

public class InfiniteCorridorHandler : MonoBehaviour
{

    public float distanceOfExpansion;
    private bool madeNextArea = false;
    public GameObject parent;



    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("entity")) return;
        if (!madeNextArea)
        {
            madeNextArea = true;
            Vector3 newTransformRight = (new Vector3(distanceOfExpansion,0,0)+transform.localPosition);
            newTransformRight.y = transform.position.y;
            print("Next Transform should be " + newTransformRight);

            GameObject next =  Instantiate(gameObject);
            next.transform.parent = gameObject.transform.parent;
            next.transform.localPosition = newTransformRight;
            
            InfiniteCorridorHandler handler = next.GetComponent<InfiniteCorridorHandler>();
            //handler.parent = parent
        }
    }
}
