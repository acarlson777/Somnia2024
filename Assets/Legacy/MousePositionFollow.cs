using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionFollow : MonoBehaviour
{
    private RectTransform rt;
    public Canvas canvas;
    private Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    private Vector2 canvasSize;



    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        canvasSize = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
    }
    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition = MultiplyVector2s(FindMousePercentOfScreenTraveled(), canvasSize);
    }

    private Vector2 FindMousePercentOfScreenTraveled()
    {
        float x, y;
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        Vector2 mousePosVec2 = new Vector2(x, y);


        return DivideVector2s(mousePosVec2, screenSize);

    }

    private Vector2 DivideVector2s(Vector2 a, Vector2 b)
    {
        float x1, x2, y1, y2;
        x1 = a.x;
        y1 = a.y;

        x2 = b.x;
        y2 = b.y;

        return new Vector2(x1 / x2, y1 / y2);
    }

    private Vector2 MultiplyVector2s(Vector2 a, Vector2 b)
    {
        float x1, x2, y1, y2;
        x1 = a.x;
        y1 = a.y;

        x2 = b.x;
        y2 = b.y;

        return new Vector2(x1 * x2, y1 * y2);
    }
}
