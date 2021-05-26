using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject godCam;
    // Start is called before the first frame update
    void Start()
    {
        godCam = GameObject.Find("Camera");
        godCam.GetComponent<Camera>().enabled = false;
        godCam.GetComponent<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            godCam.GetComponent<Camera>().enabled = true;
            godCam.GetComponent<AudioListener>().enabled = true;
            godCam.tag = "MainCamera";
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
    }
}
