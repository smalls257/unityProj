using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {



    public void LoadLevel (string sceneName)
    {
        Debug.Log("loading level: " + sceneName);
        Application.LoadLevel(sceneName);

    }


}
