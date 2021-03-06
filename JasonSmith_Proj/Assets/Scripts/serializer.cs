﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class serializer : MonoBehaviour {

    private string pathToJSON;
    private string JSONString;

    private primitiveSaveData data;

    // Use this for initialization
    void Start () {
        data = new primitiveSaveData();

        //Read from JSON
        pathToJSON = Application.streamingAssetsPath + "/primitive_" + this.transform.name + ".json";
        JSONString = File.ReadAllText(pathToJSON);
        Debug.Log(JSONString);

        JsonUtility.FromJsonOverwrite(JSONString, data);


        this.transform.position = new Vector3(data.objPosX, data.objPosY, data.objPosZ);
        this.transform.rotation = new Quaternion(data.objRotX, data.objRotY, data.objRotZ, data.objRotW);
        this.transform.localScale = new Vector3(data.scaleX, data.scaleY, data.scaleZ);
     
    }

    public void writeToJSON()
    {
        //Write data to jsonFile
        data.name = this.transform.name;
        data.objPosX = this.transform.position.x;
        data.objPosY = this.transform.position.y;
        data.objPosZ = this.transform.position.z;
        data.objRotX = this.transform.rotation.x;
        data.objRotY = this.transform.rotation.x;
        data.objRotZ = this.transform.rotation.x;
        data.scaleX = this.transform.localScale.x;
        data.scaleY = this.transform.localScale.y;
        data.scaleZ = this.transform.localScale.z;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(pathToJSON, json);

        Debug.Log("Wrote to JSON");
    }
}
