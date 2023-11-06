using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : EntityBase
{
    // Living Entities should have the following attributes:
    // - Hitpoints
    // - Speed
    // - Brain
    // Brain wil manage:
    // Entity behavior
    public Brain brain;

    public int health;
    public float speed = 1.0f;
    public List<GameObject> gameobjectsTouching = new List<GameObject>();
    //public HashSet<GameObject> gameobjectsTouching = new HashSet<GameObject>();

    new public void Start()
    {
        print("Starting from Living");


        brain = new Brain(this,interactCollider);
        print("Made Brain");
        Initialize();


    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update(); // Update normal entity stuff like physics and other stuff???    

        // update things that are specific to living entities like brain
        brain.SetSeen(gameobjectsTouching);

    }
    new public void Interact(Entity other)
    {
        print(other.GetName() + " interacted with me... a " + GetName());
    }
    public void PressInteract()
    {
        print("interacting");
        if (brain.GetClosestEntity() != null)
        {
            brain.GetClosestEntity().Interact(this);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col is BoxCollider  && col.gameObject.tag == "entity")
        {
            gameobjectsTouching.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col is BoxCollider && col.gameObject.tag == "entity") 
        {
            gameobjectsTouching.Remove(col.gameObject);
        }
    }
}
