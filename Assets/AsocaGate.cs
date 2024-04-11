using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsocaGate : MonoBehaviour
{
  CharacterDialogue character;
  public GameObject gateObject;

  // Start is called before the first frame update
  void Start()
  {
      character = gameObject.GetComponent<CharacterDialogue>();

  }

  // Update is called once per frame
  void Update()
  {
      if (character.timesInteracted >= character.lines.Count)
      {
          gateObject.SetActive(false);
      }
  }
}
