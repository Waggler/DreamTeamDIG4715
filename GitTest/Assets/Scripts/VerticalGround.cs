using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VerticalGround : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    private PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        PlayerController = GameObject.Find("CharTest_DK").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) && PlayerController.hasRhino == false)
        {
            waitTime = 0.05f;
        }

        if (Input.GetKey(KeyCode.S) && PlayerController.hasRhino == false)
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

        if (Input.GetKeyDown(KeyCode.Space) && PlayerController.hasRhino == false)
        {
            effector.rotationalOffset = 0;
        }
    }
}
