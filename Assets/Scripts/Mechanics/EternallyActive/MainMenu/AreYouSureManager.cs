using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouSureManager : MonoBehaviour
{
    [SerializeField] private GameObject areYouSureMenu;
    [SerializeField] private GameObject initialButton;

    public void showAreYouSureMenu()
    {
        areYouSureMenu.SetActive(true);
        initialButton.SetActive(false);
    }

    public void hideAreYouSureMenu()
    {
        areYouSureMenu.SetActive(false);
        initialButton.SetActive(true);
    }
}
