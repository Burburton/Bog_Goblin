using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("ThirdPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = $"Student Card: {player.GetComponent<ThirdPersonMovement>().bag["Card"]} \nCredit: {player.GetComponent<ThirdPersonMovement>().bag["Credit"]}";   


    }
}
