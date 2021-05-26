using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    float runSpeed = 3.0f;
    float walkSpeed = 2.0f;
    bool moveup = true;

    float RESETTIME = 4f;
    float changeTime = -4f;

    public GameObject detective;

    private bool detected = false;

    private bool carryCard = false;

    private float XRANGE, YRANGE;

    public CharacterController goblinController;

    public Animator animator;

    public PlayerAttribution attribution;

    public LayerMask layerMaskEnemy;

    private float detectiveRange;

    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        XRANGE = 75;
        YRANGE = 100;
        generateGoblin(XRANGE, YRANGE);
        //transform.GetComponent<Rigidbody>().useGravity = false;
        runSpeed = 3.0f;
        walkSpeed = 2.0f;
        detectiveRange = 0.5f;
        //goblinController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attribution.isAlive())
        {
            moveUp();
            movement(XRANGE, YRANGE);
            detectedPlayer();
            movementAfterDetected();
            avoidOverlap();
        }
    }

    void generateGoblin(float xRange, float zRange)
    {
        float x, z, y;
        x = Random.Range(xRange, zRange);
        z = Random.Range(xRange, zRange);
        y = -6.0f;

        transform.position = new Vector3(x, y, z);
    }

    void moveUp()
    {
        if (transform.position.y < -4.7f && moveup)
        {
            transform.Translate(transform.up * Time.deltaTime);
        }
        else moveup = false;
    }
    void movement(float xRange, float yRange)
    {
        if (!moveup && !detected)
        {
            if (changeTime <= 0)
            {
                destination = new Vector3(Random.Range(xRange, yRange), transform.position.y, Random.Range(xRange, yRange));
                Tools.modifyRotation(transform, destination);
                changeTime = RESETTIME;
            }

            if (changeTime > 0)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position, destination, walkSpeed * Time.deltaTime);
                //animator.SetBool("Walking", true);
                walkAnimation();
                changeTime -= Time.deltaTime;
            }
        }
    }

    void detectedPlayer()
    {
        if (detective.GetComponent<TargetDetective>().isDetected())
        {
            detected = true;
        }
        else detected = false;
    }

    void movementAfterDetected()
    {
        if (detected)
        {
            Vector3 playerPos = detective.GetComponent<TargetDetective>().getPlayerPos();
            Tools.modifyRotation(transform, playerPos);
            if (Vector3.Distance(transform.position, playerPos) > 0.8)
            {
                transform.localPosition = Vector3.MoveTowards(transform.position, playerPos, runSpeed * Time.deltaTime);
                runAnimation();
            }
            else
            {
                attackAnimation();
            }
        }
        else
        {
            walkAnimation();
        }
    }

    void walkAnimation()
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", false);
    }

    void idleAnimation()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", false);
    }

    void runAnimation()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Running", true);
        animator.SetBool("Attacking", false);
    }

    void attackAnimation()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", true);
    }

    public void setDetected(bool isdetected)
    {
        detected = isdetected;
    }

    public void setCarryCard()
    {
        carryCard = true;
    }

    public bool isCard()
    {
        return carryCard;
    }

    private void avoidOverlap()
    {
        if (!moveup)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectiveRange, layerMaskEnemy);

            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    if (Vector3.Distance(transform.position, collider.transform.position) == 0) break;

                    float delta1 = (detectiveRange * 2 - Vector3.Distance(transform.position, collider.transform.position)) / Vector3.Distance(transform.position, collider.transform.position);
                    
                    if (delta1 != 0)
                    {
                        //Debug.Log("hehehe");
                        Vector3 directionTemp = transform.position - collider.transform.position;
                        Vector3 dir = transform.position + directionTemp * delta1;
                        dir.y = transform.position.y;

                        transform.localPosition = Vector3.MoveTowards(transform.position, dir, runSpeed * Time.deltaTime);
                        //transform.Translate(dir * runSpeed * Time.deltaTime, Space.Self);
                    }

                }
            }
        }
    }
}
