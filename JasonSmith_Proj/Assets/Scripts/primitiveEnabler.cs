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
            foreach (Transform primChild in containerData.transform)
            {
                if (primChild.transform.gameObject.activeSelf)
                {
                    containerData.maxNumberChildEnabled = false;
                    primChild.transform.GetComponent<primitiveEnabler>().deactivate();
                    break;
                }
            }
            this.gameObject.SetActive(true);
            containerData.maxNumberChildEnabled = true;
            userLog.writeStringToLog("Loaded: " + this.transform.name);
    }

    private void deactivate()
    {
        this.transform.GetComponent<serializer>().writeToJSON();
        userLog.writeStringToLog("Closed: " + this.transform.name);
        containerData.maxNumberChildEnabled = false;
        this.gameObject.SetActive(false);
    }
}
