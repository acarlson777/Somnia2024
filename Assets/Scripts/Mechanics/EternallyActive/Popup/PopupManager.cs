using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    static bool defaultIsPriority = true;
    static GameObject currentPopup = null;
    public static GameObject Canvas = null;
    public GameObject DisplaySurface = null;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = DisplaySurface;
    }

    public static bool CreatePopUp(string resourceName)
    {
        return CreatePopUp(resourceName, defaultIsPriority);
    }
    public static bool CreatePopUp(string resourceName,bool priority)
    {
        if (currentPopup != null)
        {
            if (priority)
            {
                Destroy(currentPopup);
                currentPopup = null;
            }
            else
            {
                return false;
            }
        }
        GameObject popupObjectPrefab = Resources.Load(resourceName) as GameObject;
        if (popupObjectPrefab == null)
        {
            print("Tried to create a Popup that doesn't exist" + resourceName);
            return false;
        }
        GameObject popupObject = Instantiate(popupObjectPrefab, Canvas.transform);
        currentPopup = popupObject;
        return true;
    }
    public static bool DestroyCurrentPopUp()
    {
        if (currentPopup == null) return false;
        Destroy(currentPopup);
        currentPopup = null;
        return true;
    }
}
