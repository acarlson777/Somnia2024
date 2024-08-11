using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.WSA;

public class PostTalkDialogueActivate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterDialogue characterDialogue;
    [SerializeField] Behaviour behaviour;
    [SerializeField] GameObject secondNPCs;
    [SerializeField] GameObject firstNPCs;
    private  bool changeOccured = false;

    // Update is called once per frame
    void Update()
    {
        if (characterDialogue.timesInteracted >= 1)
        {
            if (characterDialogue.character.lineNumber == characterDialogue.character.numberOfLines.Length - 1) //might need a -1 here to work properly
            {
                behaviour.enabled = true;
                if (secondNPCs != null && !changeOccured)
                {
                    firstNPCs.SetActive(false);
                    FindObjectOfType<Player>().gameobjectsTouching.Clear();
                    secondNPCs.SetActive(true);
                    changeOccured = true;
                }
            }
        }
    }
}
