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

        sw.WriteLine(logLine);
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
