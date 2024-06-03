using UnityEngine;
using System.Collections;

public class WormContain : MonoBehaviour
{
    public GameObject walkingEntity;
    public RandomWalkSprite randomWalkSprite;
    /*
    void Start()
    {
        randomWalkSprite = walkingEntity.GetComponent<RandomWalkSprite>();
    }

    private void OnTriggerExit(Collider other)
    {
        print("Returning COL");
        if (other.Equals(this.gameObject.GetComponent<Collider>()))
        {
            randomWalkSprite.withinZone = false;
            print("Returning");
            StartCoroutine(ReturnMove());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Back to Random COL");
        if (other.Equals(wormZone))
        {
            randomWalkSprite.withinZone = true;
            print("Back to Random");
            StartCoroutine(RandomMove());
        }
    }
    */
}
