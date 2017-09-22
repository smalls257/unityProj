using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{

    private GameObject objectToSerialize;

    void Start()
    {
        objectToSerialize = GameObject.Find("PrimitiveContainer");
    }
    public void quitApp()
    {
        //get the open primitive, and close it so info will be saved.
        foreach (Transform primChild in objectToSerialize.transform)
        {
            if (primChild.gameObject.activeSelf)
            {
                primChild.GetComponent<primitiveEnabler>().toggleActive();
            }
        }
        Application.Quit();
    }
}
