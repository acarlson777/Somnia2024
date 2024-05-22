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
            List<string> dialogueToOutput = new List<string>(){"submitting rune pattern..."};
            

            List<string> password = new List<string>();
            // goes through the correct password symbols in hierarchy
            foreach (PasswordSymbol passwordSymbol in passwordSymbols)
            {
                // if its lit, add it to the players password submission
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
                else
                {
                    Debug.Log("wrong pass");
                    
                }
           

            }

            if (passwordWorked)
            {
                dialogueToOutput.Add("Patterns detected");
            } else
            {
                dialogueToOutput.Add("No patterns found");
            }

            DialogueManager.PopDialogue(dialogueToOutput.ToArray());

            bool correctSymbolsActivated = true;
            if (!passwordWorked) { return; }
            foreach (GateSymbol gate in gateSymbols)
            {
                if (!gate.glowy)
                {
                    correctSymbolsActivated = false;
                    Debug.Log("hello");
                    break;
                }
            }
            if (correctSymbolsActivated)
            {
                // we turn on ga-tae
                gateScript.OpenGate();
            }
        }
        // we celebrate >>> CELEBRATE GOOD TIMES COME ON!!!!!!!!!!!!!!!!!!

    }
}
