using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : MonoBehaviour
{
    float speed;

    float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        timeAlive = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        timeAlive += Time.deltaTime;
        if (timeAlive > 6)
        {
            Destroy(gameObject);  
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<PlayerAttribution>().isAttacked(10f);
            Destroy(gameObject);
        }
    }
}
