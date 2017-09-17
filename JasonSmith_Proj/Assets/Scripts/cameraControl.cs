using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public float speedYaw = 2;
    public float speedV = 2;

    private float yaw = 0;
    private float pitch = 0;

    private userLog userLog;

    // Use this for initialization
    void Start () {
        userLog = GameObject.FindGameObjectWithTag("UserLog").GetComponent<userLog>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButton(0) & Input.GetMouseButton(1))
	    {
            yaw += speedYaw * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            this.transform.eulerAngles = new Vector3(pitch, yaw, 0);

            userLog.writeStringToLog("Panned Camera: "+this.transform.eulerAngles);
        }

	}
}
