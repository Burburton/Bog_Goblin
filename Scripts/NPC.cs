using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private int index = 0;
    
    public Texture talkIcon;

    private bool isTalk = false;

    public GameObject player;

    public GUI text;

    public GameObject speaking;
    public GameObject goblinPool;
    public GameObject thirdPlayer;

    string task = "Dear Warrior,\nWould you like to help our student to recapture student card from Goblin which live in rog?\nAccept[Y]    Reject[N]";
    string reject = "Good luck!";
    string reward = "Would you like to convert the Student Card to credit\nAccept[Y]    Reject[N]";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "NPC" && Input.GetMouseButtonDown(0))
            {
                isTalk = true;
            }
        }
        NPCTalk();
    }

    void NPCTalk()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(player.transform.position.x, 0, player.transform.position.z)) < 10)
        {


            if (thirdPlayer.GetComponent<ThirdPersonMovement>().bag["Card"] != 0)
            {
                speaking.GetComponent<Text>().text = reward;
                if (speaking.activeInHierarchy)
                {
                    if (Input.GetKeyDown(KeyCode.Y))
                    {
                        thirdPlayer.GetComponent<ThirdPersonMovement>().bag["Credit"] += thirdPlayer.GetComponent<ThirdPersonMovement>().bag["Card"] * 10;
                        thirdPlayer.GetComponent<ThirdPersonMovement>().bag["Card"] = 0;
                        speaking.SetActive(false);
                    }
                    if (Input.GetKeyDown(KeyCode.N))
                    {
                        speaking.GetComponent<Text>().text = task;
                        speaking.SetActive(false);
                        isTalk = false;
                    }
                }

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                isTalk = true;
            }

            Tools.modifyRotation(transform, player.transform.position);

            if (isTalk)
            {
                speaking.SetActive(true);
                speaking.GetComponent<Text>().text = task;
            }

            if (speaking.activeInHierarchy && speaking.GetComponent<Text>().text == task)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    GameObject.Instantiate(goblinPool);
                    speaking.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    speaking.GetComponent<Text>().text = reject;
                    isTalk = false;
                }
            }

            isTalk = false;
        }
        else
            speaking.SetActive(false);
    }

    
}
