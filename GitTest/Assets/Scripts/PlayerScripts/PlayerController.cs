using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public float jumpPower = 20f; //determines height of jump
    public float moveSpeed = 5f; //determines move speed
    public float sprintSpeed = 10f; //determines move speed when sprinting
    public float crouchSpeed = 2f; ////determines move speed when crouching 
    /*
    public float dashForce;
    public float currentDashTimer;
    public float startDashTimer;
    public float dashDirection;
    float movX;
    */
    public bool isGrounded = true;
    //public bool hasJumped = false;
    public bool isDashing = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        /*
        movX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && movX != 0)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            rb.velocity = Vector2.zero;
            dashDirection = (int)movX;

        }
        if (isDashing)
        {
            rb.velocity = transform.right * dashDirection * dashForce;

            currentDashTimer -= Time.deltaTime;

            if(currentDashTimer <= 0)
            {
                isDashing = false;
            }
        }
        */

        if (Input.GetButton("shift") == true) //if shift is held, increase jumpPower and moveSpeed
        {
            moveSpeed = sprintSpeed; //set move speed to increased sprint speed
            jumpPower = 25f; //increase jumpPower
            //isDashing = true; // set dashing to true

            Debug.Log("Start Sprinting");
        }
        else if(Input.GetKey("s")) //if s is held, decrease moveSpeed
        {
            moveSpeed = crouchSpeed; //set move speed to reduced crouch speed

            Debug.Log("Crouched");
        }
        else
        {
            moveSpeed = 5f; //reset moveSpeed and jumpPower variables
            jumpPower = 20f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //set horiztonal movement parameters
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
    void Jump() //method with Jump and Ground check
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true) //if the jump button is pressed and the player is on the ground, the player jumps
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse); //jumps to the height of jump power

            Debug.Log("Jumped");
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfDead(collision);
    }
    public void CheckIfDead(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }

    /*private void oldJump()
    {
        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            hasJumped = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 25f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            hasJumped = false;
        }
    }*/
}

