using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{

    //void Awake()
    //{
    //    Screen.SetResolution(1024, 768, true);
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void modifyRotation(Transform origin, Vector3 target)
    {
        Vector3 forward_dir = target - origin.position;
        Quaternion rotate = Quaternion.FromToRotation(origin.forward, forward_dir);
        float angle = rotate.eulerAngles.y;
        origin.Rotate(Vector3.up, angle);
    }

    public static bool checkDirection(GameObject first, GameObject other)
    {
        Vector3 dir = (other.transform.position - first.transform.position).normalized;
     
        float direction = Vector3.Dot(first.transform.forward, dir);
        
        if (direction > 0.5f)
        {
            return true;
        }

        return false;
    }

    public static float getDistance(GameObject first, GameObject other)
    {
        return Mathf.Abs(Vector3.Distance(first.transform.position, other.transform.position));
    }
}
