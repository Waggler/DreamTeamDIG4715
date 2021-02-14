using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGround : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.05f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.05f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
