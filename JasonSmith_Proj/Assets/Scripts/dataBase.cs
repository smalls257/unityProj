using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using System.Data;
using System;
using System.IO;
using MySql.Data.MySqlClient;

public class dataBase : MonoBehaviour
{

    private MySqlConnection myConnection;
    private string connString;

    void Start()
    {
        connString = "Server = intprog.cxd1uib1clyq.us-east-1.rds.amazonaws.com; " +
        "Database = login;" +
        "Uid = chaun;" +
        "Pwd = chaun1234;";

    }

    public bool validLogin(string username, string password)
    {
        string query = "select * from Users where user = '" + username + "' and pass = '" + password + "';";
        MySqlDataReader reader;
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {                    
                    reader.Close();
                    return true;
                }
                else if (count > 1)
                {
                    Debug.Log("Duplicate username and password");
                }
                else
                {
                    Debug.Log("username and password incorrect");
                }
                reader.Close();

                return false;
            }
        }
    }

 

}
