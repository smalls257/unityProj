using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine;

public class primitiveInteraction : MonoBehaviour
{
    //Position information
    private Vector3 distance;
    private float posX;
    private float posY;

    public float rotationSpeed = 1;
    public float scaleFactor = .5f;

    private userLog userLog;

    void Start ()
    {
        userLog = GameObject.FindGameObjectWithTag("UserLog").GetComponent<userLog>();

    }

    void Update () {

        //Scale Object
	    if (Input.GetAxis("Mouse ScrollWheel") != 0)
	    {
	        float scroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 scaleFactorVector3 = Vector3.one*scaleFactor*scroll;

	        this.transform.localScale += scaleFactorVector3;

            userLog.writeStringToLog("Scaled: "+this.transform.name+ " , "+transform.lossyScale);
	    }

        //Rotate Object
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(rotationSpeed* rotationY, -rotationSpeed * rotationX, 0, Space.World);
            userLog.writeStringToLog("Rotated: "+this.transform.name+" , "+transform.rotation);
        }
    }

    //Moving the Object
    void OnMouseDown() //Get current mouse position
    {
        distance = Camera.main.WorldToScreenPoint(this.transform.position);
        posX = Input.mousePosition.x - distance.x;
        posY = Input.mousePosition.y - distance.y;
    }
    void OnMouseDrag() 
    {

        //Move object
        Vector3 mousePos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY,
            distance.z);

        //move obj to position
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        userLog.writeStringToLog("Moved: "+this.transform.name+" , "+ transform.position);
    }
}
