using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Text>().text = "Click or T to Talk\nClick or A to Attack";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
