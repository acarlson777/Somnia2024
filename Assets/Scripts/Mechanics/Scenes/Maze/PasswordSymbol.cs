using UnityEngine;
using System.Collections;

public class PasswordSymbol : InteractableObject, Entity
{

    [SerializeField] private bool lit = false;
    public new void Start()
    {
        base.Start();
    }

    public new void Update()
    {
        base.Update();
    }
    public bool getLit()
    {
        return lit;
    }
    public new void Interact(Entity entity)
    {
        // if the player has interacted with us then just light on or off!
        lit = !lit;
        Material onMat = GameObject.Find("Gate").GetComponent<Renderer>().material;
        gameObject.GetComponent<Renderer>().material = onMat;
    }       
}