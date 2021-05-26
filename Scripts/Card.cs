using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    GameObject player;
    public bool valuable;
    public LayerMask layer;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        valuable = false;
    }

    // Update is called once per frame
    void Update()
    {
        Dropping();
        wasPickup();
    }

    private void Dropping()
    {
        if (transform.position.y > player.transform.position.y + 0.2)
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -transform.position.y + player.transform.position.y + 0.2f), 2f * Time.deltaTime);
        }
        else
        {
            valuable = true;
        }
    }

    private void wasPickup()
    {
        if (valuable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 100f, layer))
                {
                    if (hit.collider.tag == "Card")
                    {
                        if (Tools.getDistance(player, gameObject) < 1f)
                        {
                            player.GetComponent<ThirdPersonMovement>().pickupItem("Card");
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
