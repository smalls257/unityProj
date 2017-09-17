using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class userLog : MonoBehaviour {

    private string pathLog;
    private StreamWriter sw;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        pathLog = Application.streamingAssetsPath + "/UserLog.txt";
    }

    public void writeStringToLog(string text)
    {
        text += System.Environment.NewLine;
        sw = new StreamWriter(pathLog, true);
        sw.Write(text);
        sw.Close();
    }

}
