using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio2 : MonoBehaviour
{

    public GameObject obje;
    GameObject obj = null;
    // Start is called before the first frame update
    void Start()
    {
        if (GUI.Button(new Rect(10, 10, 120, 30), "load level"))
        {
            if (Application.loadedLevelName == "StartPage")
            {
                Application.LoadLevel("SettingPage");
            }
            else
            {
                Application.LoadLevel("StartPage");
            }

        }
        obj = GameObject.FindGameObjectWithTag("sound");
        if (obj == null)
        {
            obj = (GameObject)Instantiate(obje);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
