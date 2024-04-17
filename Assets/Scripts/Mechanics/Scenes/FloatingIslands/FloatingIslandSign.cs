using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingIslandSign : MonoBehaviour
{
    [SerializeField] TMP_Text text_box;
    public IslandSelectorUpDown[] selectors;
#if UNITY_EDITOR
    private const uint frame_skips = 100;
#else
    private const uint frame_skips = 2;
#endif
    private uint frame = frame_skips;

    private void Update()
    {
        frame--;
        if (frame != 0) return;
        frame = frame_skips;


        foreach (IslandSelectorUpDown selector in selectors)
        {
            if (selector.isOn)
            {
                if (!text_box.text.Equals(selector.showName))
                    text_box.text = selector.showName;
                return;
            }
        }
        if (text_box.text != "")
        {
            text_box.text = "";
        }

    }
}
