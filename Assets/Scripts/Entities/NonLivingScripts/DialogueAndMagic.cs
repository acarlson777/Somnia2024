using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAndMagic : GeneralInteractable, Entity
{
    [SerializeField] List<GameObject> imps = new();
    private List<GameObject> previouslyDeaded = new();
    private bool done = false;
    // Start is called before the first frame update
    new public void Start()
    {
        previouslyDeaded.Clear();
        base.Start();
    }
    new public void Interact(Entity entity)
    {
        if (entity is Player)
        {
            if (timesInteracted == lines.Count)
            {
                if (!done)
                {
                    //we are done

                    done = true;
                }

            }
            else
            {
                print("putting a dialogue" + timesInteracted);

                DialogueManager.PopDialogue(ParseTalks(lines[timesInteracted].lines));
                timesInteracted++;
            }
        }
    }


    /// <summary>
    /// This function will take in a string an execute any code that may be contained in there
    /// and then return the sanitized version of the code
    /// </summary>
    /// <param name="text"></param>
    /// <returns>Talkable Text</returns>
    protected string[] ParseTalks(string[] lines)
    {
        string[] parsed = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string text = lines[i];
            int first = text.IndexOf('^');
            if (first != -1)
            {
                int second = text.IndexOf('^', first + 1);
                if (second != -1)
                {

                    string code = text.Substring(first + 1, second - first - 1);
                    text = text.Substring(0, first) + text.Substring(second + 1);
                    // this is the code taht will set objects to a active or inactive state

                    string[] splits = code.Split(':');
                    Debug.Log("Parsed: " + splits[0] +" -> " + splits[1]);
                    string name = splits[0];

                    bool activity = splits[1].ToLower().Substring(0, 1).Equals("t");

                    GameObject obj = GameObject.Find(name);
                    if (obj == null)
                    {
                        foreach (GameObject g in previouslyDeaded)
                        {
                            if (name.Equals(g.name))
                            {
                                obj = g;
                            }
                        }
                    }
                    if (obj == null)
                    {
                        foreach (GameObject g in imps)
                        {
                            if (name.Equals(g.name))
                            {
                                obj = g;
                            }
                        }
                    }

                    if (obj != null)
                    {
                        print("Could find object of name: " + name);

                        if (!activity)
                        {
                            previouslyDeaded.Add(obj);
                        }
                        print("Settings it to " + activity);
                        obj.SetActive(activity);
                    }
                    else
                    {
                        print("couln't find object of name!!");
                    }
                }

            }
            parsed[i] = text;
        }
        return parsed;
    }

    public static string ParseSceneGoto(string str)
    {

        int index;
        string sceneGoto;
        index = str.IndexOf('{');
        if (index != -1)
        {
            int endex = str.IndexOf('}');
            if (endex != -1)
            {
                sceneGoto = str.Substring(index+1,endex-index-1);
                str = str.Substring(0, index) + str.Substring(endex + 1);
                Debug.Log("Going to Scene: \"" + sceneGoto + "\"");
                InstantiateLoadingScreen.Instance.LoadNewScene(sceneGoto);
            }
        } 
        return str;
    }

}