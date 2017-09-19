using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primitiveEnabler : MonoBehaviour {

    private userLog userLog;

    private primitiveContainerData containerData;
    void Awake()
    {
        userLog = GameObject.FindGameObjectWithTag("UserLog").GetComponent<userLog>();
    }

    public void toggleActive()
    {
        containerData = transform.parent.GetComponent<primitiveContainerData>();
        if (this.gameObject.activeSelf)
        {
            //deactiviate primitive
            this.transform.GetComponent<serializer>().writeToJSON();
            userLog.writeStringToLog("Closed: " + this.transform.name);
            containerData.maxNumberChildEnabled = false;
            this.gameObject.SetActive(false);
        }

        else if (containerData.maxNumberChildEnabled == false)
        {
            this.gameObject.SetActive(true);
            containerData.maxNumberChildEnabled = true;
            userLog.writeStringToLog("Loaded: " + this.transform.name);

        }
    }
}
