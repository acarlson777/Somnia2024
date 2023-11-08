using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubmitPasswordButton : InteractableObject, Entity
{
    // This is the class that should hold most of the logic for the Maze scene
    public GateSymbol[] gateSymbols;
    public PasswordSymbol[] passwordSymbols;
    public MazeGate gateScript;


    public new void Start()
    {
        base.Start();
        gateScript.CloseGate();
    }

    public new void Update()
    {
        base.Update();
    }

    public new void Interact(Entity entity)
    {
        List<string> password = new List<string>();
        foreach (PasswordSymbol passwordSymbol in passwordSymbols)
        {
            if (passwordSymbol.getLit())
            {
                password.Add(passwordSymbol.symbol);
            }
        }

            if (entity is Player)
            {
                foreach (GateSymbol gateSymbol in gateSymbols)
                {
                    bool passwordWorked = gateSymbol.submitPassword(password.ToArray());
                    
                }
            }
    }
}
