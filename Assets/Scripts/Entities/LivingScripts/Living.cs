using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : EntityBase
{
    // Living Entities should have the following attributes:
    // - Hitpoints
    // - Speed
    // - Brain
    public Brain brain;
    public int health;
    public float speed = 1.0f;

    new void Start()
    {
        
        Initialize();

    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
   
}
