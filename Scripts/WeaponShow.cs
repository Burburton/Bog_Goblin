using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShow : MonoBehaviour
{

    public ThirdPersonMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getWeapon())
        {
            transform.GetComponent<Text>().text = "Weapon: Sword\n(Press S to swap weapons)";
        }
        else
        {
            transform.GetComponent<Text>().text = "Weapon: Magic\n(Press S to swap weapons)";
        }
    }
}
