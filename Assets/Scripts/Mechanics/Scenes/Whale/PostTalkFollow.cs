using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PostTalkFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CharacterDialogue characterDialogue;
    [SerializeField] SphinxReal sphinxReal;
    [SerializeField] private GameObject preTalkCharacter;
    [SerializeField] private GameObject postTalkCharacter;
    [SerializeField] private GameObject postTalkCharacterChild;
    [SerializeField] private RuntimeAnimatorController baldCharacter;

    // Update is called once per frame  
    void Update()
    {
        if (characterDialogue.character != null)
        {
            if (characterDialogue.character.lineNumber == characterDialogue.character.numberOfLines.Length - 1) //might need a -1 here to work properly
            {
                preTalkCharacter.SetActive(false);
                postTalkCharacter.SetActive(true);
            }
        }

        if (sphinxReal.character != null)
        {
            if (sphinxReal.character.lineNumber == 5)
            {
                postTalkCharacterChild.GetComponent<Animator>().runtimeAnimatorController = baldCharacter;
            }
        }
    }
}
