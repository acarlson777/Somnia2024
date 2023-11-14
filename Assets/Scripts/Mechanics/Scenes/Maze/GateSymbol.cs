using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        HashSet<string> actualPassword = new HashSet<string>(password);
        HashSet<string> userPassword = new HashSet<string>(passwordSubmitted);
        if (actualPassword.SetEquals(userPassword))
        {
            glowy = true;
            return true;
        }
        else return false;
    }
}