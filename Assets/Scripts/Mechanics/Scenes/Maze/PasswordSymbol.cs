using UnityEngine;
using System.Collections;

public class PasswordSymbol : InteractableObject, Entity
{

    [SerializeField] private bool lit = false;
    public string symbol = "";
    public Material startingMat;
    public Material onMat;
    public new void Start()
    {
        base.Start();
        startingMat = gameObject.GetComponent<Renderer>().material;
    }

    public new void Update()
    {
        base.Update();
    }
    public bool getLit()
    {
        // to tell the submit button to add the symbols that are lit
        return lit;
    }
    public new void Interact(Entity entity)
    {
        // if the player has interacted with us then just light on or off!
        lit = !lit;
        if (lit)
        {
            gameObject.GetComponent<Renderer>().material = onMat;
        }
        else
        {
            // unlights itself after second interaction
            gameObject.GetComponent<Renderer>().material = startingMat;
        }
    }       
}