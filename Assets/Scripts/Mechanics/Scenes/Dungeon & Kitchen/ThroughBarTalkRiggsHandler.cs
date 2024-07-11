using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughBarTalkRiggsHandler : MonoBehaviour
{
    [SerializeField] private RiggsManager riggsManager;
    [SerializeField] private DungeonManager dungeonManager;

    void Update()
    {
        if (dungeonManager.doPreventGateFromClosing)
        {
            riggsManager.switchToNextRiggs();
        }
    }
}
