using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PostTalkFollowGumdropGirl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SphinxReal sphinxReal;
    [SerializeField] private GameObject preTalkCharacter;
    [SerializeField] private GameObject postTalkCharacter;

    // Update is called once per frame  
    void Update()
    {
        if (sphinxReal.dollComplete)
        {
            preTalkCharacter.SetActive(false);
            postTalkCharacter.SetActive(true);
        }
    }
}
