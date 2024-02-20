using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinnerBell : InteractableObject, Entity
{
    public bool rung = false;
    public GameObject symbol;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (rung) symbol.gameObject.SetActive(true);
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            rung = true;
        }
    }
}
