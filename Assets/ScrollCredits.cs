using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollCredits : MonoBehaviour
{
    public TextMeshProUGUI roleText;
    public TextMeshProUGUI nameText;
    public float scrollSpeed = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roleText.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        nameText.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
