using UnityEngine;
using System.Collections;

public class GateSymbol : InteractableObject, Entity
{
    public string[] password; // this will hold an array of string which must be true and nothing else must be true for this symbol to be turned on.
    public bool glowy = false;

    public new void Start()
    {
        base.Start();
    }

    public new void Update()
    {
        base.Update();
    }

    public new void Interact(Entity entity)
    {

    }
    public bool submitPassword(string[] passwordSubmitted)
    {
        if (password.Length != passwordSubmitted.Length) return false;

        for (int i = 0; i < password.Length; i++)
        {
          if (password[i] != passwordSubmitted[i])
            {
                return false;
            }
        }
        // become glowy
        return true;
    }
}