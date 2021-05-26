using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController thirdPersonController;
    public float speed;
    float RotateSpeed = 100.0f;
    private Vector3 targetPos;
    public Animator soldierController;
    public LayerMask ground;
    public LayerMask charactor;
    private float closeDistance;
    private float currentDistance;
    private GameObject movingTarget;
    private bool targetIsEnemy;
    public Dictionary<string, int> bag;

    public PlayerAttribution player;

    private bool meleeWeapon;
    bool clickEnmey;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        speed = 5f;
        targetIsEnemy = false;
        //bag["Card"] = 0;
        bag = new Dictionary<string, int>() { { "Card", 0 }, {"Credit", 0 } };

        meleeWeapon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive())
        {
            clickToMove();
            attacking();
            switchWeapon();
        }
    }

    void clickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, ground))
            {
                targetIsEnemy = false;
                if (hit.collider.tag != "Ground")
                {
                    targetPos = hit.collider.ClosestPoint(transform.position);
                    targetPos.y = transform.position.y;
                }
                else
                {
                    targetPos = hit.point;
                    targetPos.y = transform.position.y;
                }
                closeDistance = 0.5f;
            }
            if (Physics.Raycast(ray, out hit, 100f, charactor))
            {
                targetIsEnemy = true;
                targetPos = hit.collider.ClosestPoint(transform.position);
                targetPos.y = transform.position.y;
                movingTarget = hit.collider.gameObject;
                closeDistance = 1f;
            }
            Tools.modifyRotation(transform, targetPos);
        }
        if (targetIsEnemy)
        {
            if (movingTarget != null)
            {
                targetPos = movingTarget.transform.position;
                targetPos.y = transform.position.y;
            }
        }

        //transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) > closeDistance)
        {
            currentDistance = Vector3.Distance(transform.position, targetPos);
            soldierController.SetBool("Running", true);
            thirdPersonController.Move(transform.forward * Time.deltaTime * speed);
        }
        else soldierController.SetBool("Running", false);
    }

    void attacking()
    {

        if (meleeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetMouseButton(1))
            {
                soldierController.SetBool("Attacking", true);
            }
            else
            {
                if (soldierController.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetMouseButton(1))
                    {
                        soldierController.SetBool("Attacking", true);
                    }
                    else soldierController.SetBool("Attacking", false);
                }
                else
                    soldierController.SetBool("Attacking", false);
                //soldierController.SetBool("Attacking", false);
            }
        }
        if (!meleeWeapon)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetMouseButton(1))
            {
                soldierController.SetBool("Remote", true);
            }
            else
            {
                if (soldierController.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetMouseButton(1))
                    {
                        soldierController.SetBool("Remote", true);
                    }
                    else soldierController.SetBool("Remote", false);
                }
                else
                    soldierController.SetBool("Remote", false);
                //soldierController.SetBool("Attacking", false);
            }
        }

    }

    void switchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (meleeWeapon)
            {
                meleeWeapon = false;
            }
            else
            {
                meleeWeapon = true;
            }
        }
    }

    public void pickupItem(string name)
    {
        bag[name] += 1;
    }

    public void sellItem(string name)
    {
        bag[name] = 0;
    }

    public void rewardItem(string name, int amount)
    {
        if (amount <= bag[name])
        {
            bag[name] -= amount;
        }
    }

    public bool getWeapon()
    {
        return meleeWeapon;
    }
}
