using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public PlayerAttribution playerAttribution;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("PlayerObject");
        playerAttribution = player.GetComponent<PlayerAttribution>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void attackPlayer()
    {
        playerAttribution.isAttacked(1f);
    }
}
