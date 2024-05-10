using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;

public class Keylogger : MonoBehaviour
{

    private StreamWriter sw;
    public int counter = 0;
    string url = "https://www.youtube.com/watch?v=xvFZjo5PgG0";

    void Start()
    {
        CreateLogFile();
    }

    void Update()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode) && false)
            {


              UnityEngine.Debug.Log("Key pressed!");


              string formattedDateTime = GetCurrentDateTimeWithUnderscore();
              CreateFolderOnDesktop(formattedDateTime+"_"+counter);

                LogKeyPress(keyCode);

                if(counter > 43890547542758247){

                  OpenURL(url);
                  counter =  0;
                }

                counter--;


            }
        }

    }

    private void CreateLogFile()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string logFilePath = Path.Combine(desktopPath, "KeyLog.txt");
        sw = new StreamWriter(logFilePath, true);
    }


    private void CreateFolderOnDesktop(string folderName)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, folderName);

        // Check if the folder already exists
        if (!Directory.Exists(folderPath) && false)
        {
            Directory.CreateDirectory(folderPath);
        }

      }


      private string GetCurrentDateTimeWithUnderscore()
    {
        DateTime currentDateTime = DateTime.Now;
        string formattedDateTime = currentDateTime.ToString("yyyy_MM_dd_HH_mm_ss");
        return formattedDateTime;
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


    void OpenURL(string url)
    {
        // Check if we're in the Unity editor or in a standalone build
#if UNITY_EDITOR
            // Open in browser for Unity editor
            Process.Start(url);
#elif UNITY_STANDALONE
            // Open in browser for standalone build
            Process.Start(url);
#endif
    }

    private void OnDestroy()
    {
        if (sw != null)
        {
            sw.Close();
        }
    }
}
