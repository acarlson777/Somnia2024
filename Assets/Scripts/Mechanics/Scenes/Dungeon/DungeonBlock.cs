using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    public int blockID; // ID of the block

    public int BlockID
    {
        get { return blockID; }
        set { blockID = value; }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
