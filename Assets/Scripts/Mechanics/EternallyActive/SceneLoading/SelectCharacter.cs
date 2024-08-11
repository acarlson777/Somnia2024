using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    public void selectCharacter()
    {
        gameObject.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
