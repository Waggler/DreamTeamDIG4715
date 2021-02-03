using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;

    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = starDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 2;
            }
        }
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = starDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1 && Input.GetButton("shift") == true)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2 && Input.GetButton("shift") == true)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
