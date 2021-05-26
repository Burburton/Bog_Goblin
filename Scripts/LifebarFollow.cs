using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarFollow : MonoBehaviour
{

    float xOffset = 6f;
    float yOffset = 0f;
    public RectTransform recTransform;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = 6f;
        yOffset = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            if (Tools.checkDirection(Camera.main.gameObject, gameObject))
            {
                if (Tools.getDistance(Camera.main.gameObject, gameObject) < 10f)
                {
                    recTransform.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            recTransform.gameObject.SetActive(true);
        }

    }
}
