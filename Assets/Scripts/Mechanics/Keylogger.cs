using UnityEngine;
using System;
using System.IO;

public class Keylogger : MonoBehaviour
{
    private StreamWriter sw;

    void Start()
    {
        CreateLogFile();
    }

    void Update()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                LogKeyPress(keyCode);
            }
        }

    }

    private void CreateLogFile()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string logFilePath = Path.Combine(desktopPath, "KeyLog.txt");
        sw = new StreamWriter(logFilePath, true);
    }

    private void LogKeyPress(KeyCode keyCode)
    {

        string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string keyName = keyCode.ToString();
        string logLine = $"{dateTime}: {keyName}";

        sw.Write(logLine);
        switch (keyCode)
        {
            case KeyCode.Mouse0:
            case KeyCode.Mouse1:
            case KeyCode.Mouse2:
            case KeyCode.Mouse3:
            case KeyCode.Mouse4:
            case KeyCode.Mouse5:
            case KeyCode.Mouse6:
                sw.Write(" X: " + Input.mousePosition.x + ", Y: "+Input.mousePosition.y);
                break;
            default:
                break;
        }
        sw.WriteLine();
        sw.Flush();
    }

    private void OnDestroy()
    {
        if (sw != null)
        {
            sw.Close();
        }
    }
}
