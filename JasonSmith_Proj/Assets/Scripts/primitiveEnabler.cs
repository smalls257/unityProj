using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primitiveEnabler : MonoBehaviour {

    private userLog userLog;

    void Awake()
    {
        userLog = GameObject.FindGameObjectWithTag("UserLog").GetComponent<userLog>();

    }

    public void toggleActive()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.GetComponent<serializer>().writeToJSON();
            userLog.writeStringToLog("Closed: " + this.transform.name);

            this.gameObject.SetActive(false);
        }

        else
        {
            this.gameObject.SetActive(true);
            userLog.writeStringToLog("Loaded: " + this.transform.name);

        }
    }
}
