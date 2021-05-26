using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetective : MonoBehaviour
{
    private bool detected = false;

    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Vector3 target = other.transform.position - transform.position;
            //float angle = Vector3.Angle(transform.forward, target); //求出两向量之间的夹角
            //Vector3 normal = Vector3.Cross(transform.forward, target);//叉乘求出法线向量
            //angle *= Mathf.Sign(Vector3.Dot(normal, transform.up));  //求法线向量与物体上方向向量点乘，结果为1或-1，修正旋转方向
            //Debug.Log("angloe" + angle);
            //if (0 < angle && angle < 50)
            //{
            playerPosition = other.transform.position;
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = false;
        }
    }

    public bool isDetected()
    {
        return detected;
    }

    public Vector3 getPlayerPos()
    {
        return playerPosition;
    }
}
