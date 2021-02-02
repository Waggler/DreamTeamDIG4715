using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public float jumpPower = 25f;
    public float moveSpeed = 7.5f;
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public bool isGrounded = true;
    public bool hasJumped = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void Update()
    {
        Jump();
        if (Input.GetButton("shift") == true)
        {
            moveSpeed = sprintSpeed;
            jumpPower = 50f;
            Debug.Log("Start Sprinting");
        }
        else
        {
            moveSpeed = 5f;
            jumpPower = 25f;
        }
            
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    /*void crouchCheck()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //moveSpeed = crouchSpeed;
        }
        //moveSpeed = 5f;
    }*/

    void sprintCheck()
    {
        
        

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }

    }
    /*private void Jump()
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

