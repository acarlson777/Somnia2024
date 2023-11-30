using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateSymbol : InteractableObject, Entity
{
    public string[] password; // this will hold an array of string which must be true and nothing else must be true for this symbol to be turned on.
    public bool glowy = false;
    public Material startingMat;
    public Material onMat;
    public List<Voicelines> lines;
    private int timesInteracted = 0;

    public new void Start()
    {
        base.Start();
        gameObject.GetComponent<Renderer>().material = startingMat;
    }

    public new void Update()
    {
        base.Update();
    }

    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (timesInteracted >= lines.Count)
            {
                timesInteracted = lines.Count - 1;
            }
            print("putting a dialogue" + timesInteracted);
            DialogueManager.PopDialogue(lines[timesInteracted].lines);
            timesInteracted++;

        }
    }
    [System.Serializable]
    public class Voicelines
    {
        public string[] lines;
    }

    public bool submitPassword(string[] passwordSubmitted)
    {
        if (password.Length != passwordSubmitted.Length) return false;

        HashSet<string> actualPassword = new HashSet<string>(password);
        HashSet<string> userPassword = new HashSet<string>(passwordSubmitted);
        if (actualPassword.SetEquals(userPassword))
        {
            glowy = true;
            gameObject.GetComponent<Renderer>().material = onMat;
            return true;
        }
        else return false;
    }
}