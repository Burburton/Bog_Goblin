using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

public class GoblinPool : MonoBehaviour
{
    
    int amount;
    GameObject[] goblinPool;
    bool create = false;
    public GameObject goblin;
    public bool detected = false;
    float timeAlive = 0f;

    // Start is called before the first frame update
    void Start()
    {
        amount = 10;
        goblinPool = new GameObject[amount];
        int temp = Random.Range(0, amount);
        for(int i = 0; i< amount; i++)
        {
            GameObject newGoblin = GameObject.Instantiate(goblin);
            goblinPool[i] = newGoblin;
            if (temp == i)
            {
                //goblinPool[i].GetComponent<GoblinMovement>().setCarryCard();
                goblinPool[i].GetComponent<PlayerAttribution>().setCarryCard();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 2)
        {
            Destroy(gameObject);
        }
    }
}
