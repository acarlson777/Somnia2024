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

        if (entity is Player)
        {
            List<string> password = new List<string>();
            foreach (PasswordSymbol passwordSymbol in passwordSymbols)
            {
                if (passwordSymbol.getLit())
                {
                    password.Add(passwordSymbol.symbol);
                }
            }
            bool passwordWorked = false;
            foreach (GateSymbol gateSymbol in gateSymbols)
            {
                if(gateSymbol.submitPassword(password.ToArray()))
                {
                    passwordWorked = true;
                }
           

            }
            bool ALLACTIVE_uArerVeryEffective = true;
            if (!passwordWorked) { return; }
            foreach (GateSymbol gate in gateSymbols)
            {
                if (!gate.glowy)
                {
                    ALLACTIVE_uArerVeryEffective = false;
                    break;
                }
            }
            if (ALLACTIVE_uArerVeryEffective)
            {
                // we turn on ga-tae
                gateScript.OpenGate();
            }
        }
        // we celebrate >>> CELEBRATE GOOD TIMES COME ON!!!!!!!!!!!!!!!!!!

    }
}
