using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginScript : MonoBehaviour {

    public GameObject database;
    private dataBase db;
    public GameObject sceneLoader;
    private SceneLoader sl;

    public string username;
    public string password;

    public InputField Username;
    public InputField Password;

    private userLog userLog;
    // Use this for initialization
    void Start()
    {
        userLog = GameObject.FindGameObjectWithTag("UserLog").GetComponent<userLog>();
        Username.onValueChange.AddListener(delegate { usernameChanged(Username.text); });
        Password.onValueChange.AddListener(delegate { passwordChanged(Password.text); });

    }

 
    public void usernameChanged(string textEntered)
    {
        username = textEntered;
    }

    public void passwordChanged(string textEntered)
    {
        password = textEntered;
    }

    public void login()
    {
        var db = database.GetComponent<dataBase>();
        var sl = sceneLoader.GetComponent<SceneLoader>();
        bool validLogin = db.validLogin(username, password);
        if (validLogin)
        {
            userLog.writeStringToLog("Successful Login: "+username+" "+password);
            sl.LoadLevel("main");
        }

        else if (validLogin == false)
        {
            userLog.writeStringToLog("Bad Login: " + username + " " + password);

        }

    }
}
