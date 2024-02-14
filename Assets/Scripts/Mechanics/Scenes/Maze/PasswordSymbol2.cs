using UnityEngine;
using System.Collections;

public class PasswordSymbol2 : InteractableObject, Entity
{

    [SerializeField] private bool lit = false;
    public string symbol = "";
    public GameObject lightUpObject;
    public Material startingMat;
    public Material onMat;
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
        // to tell the submit button to add the symbols that are lit
        return lit;
    }
    public new void Interact(Entity entity)
    {
        // if the player has interacted with us then just light on or off!
        lit = !lit;
        if (lit)
        {
            lightUpObject.GetComponent<Renderer>().material = onMat;
            //Move down so that half is showing
        }
        else
        {
            // unlights itself after second interaction
            lightUpObject.GetComponent<Renderer>().material = startingMat;
            //move back up so that all is showing
        }
    }       
}