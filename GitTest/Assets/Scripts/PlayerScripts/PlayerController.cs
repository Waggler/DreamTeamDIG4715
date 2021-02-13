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

    public bool isRolling = false;

    public bool canDash = true;
    public float rollingTime;
    public float rollSpeed;
    public float rollWait = 2f;

    private int direction;

    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Rhino;

    public AudioSource aSource;
    public AudioClip deathGrunt;
    public AudioClip bigDeathGrunt;
    public AudioClip whack;
    public AudioClip letter;
    public AudioClip balloon;
    public AudioClip jump;


    /*
    public float rollDistance = 30f;
    public float rollTimer = 0f;
    */

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
    public bool hasRhino = false;

    public Transform obj;

    Rigidbody2D rb;

    public Animator animator;

    
    float horizontalMove = 0f;
    private SpriteRenderer mySpriteRenderer; // variable to hold a reference to our SpriteRenderer component
  

    private void Awake() // This function is called just one time by Unity the moment the component loads
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();// get a reference to the SpriteRenderer component on this gameObject
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        obj = GameObject.FindWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
            direction = 1;
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsWalking", true);
            direction = 2;
            mySpriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true && hasRhino == false)
        {
            dkRoll();
        }

        if (Input.GetButton("shift") == true && hasRhino == false && isGrounded == true) //if shift is held, increase jumpPower and moveSpeed
        {
            animator.SetBool("IsSprinting", true);
            moveSpeed = sprintSpeed; //set move speed to increased sprint speed
            jumpPower = 25f; //increase jumpPower
            
            Debug.Log("Start Sprinting");
        }
        else if (Input.GetKey("s")) //if s is held, decrease moveSpeed
        {
            moveSpeed = crouchSpeed; //set move speed to reduced crouch speed

            Debug.Log("Crouched");
        }
        else if (hasRhino == true)
        {
            moveSpeed = 10f; //reset moveSpeed and jumpPower variables
            jumpPower = 10f;
        }
        else
        {
            moveSpeed = 5f; //reset moveSpeed and jumpPower variables
            jumpPower = 20f;
            animator.SetBool("IsSprinting", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsRhino", false);
            hasRhino = false;
            
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //set horiztonal movement parameters
        transform.position += movement * Time.deltaTime * moveSpeed;
        //animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        /*
        rollTimer += Time.deltaTime;

        if (rollTimer > rollWait)
        {
            rollTimer = rollTimer - rollWait;
            isDashing = false;
        }
        */
    }
    void Jump() //method with Jump and Ground check
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true) //if the jump button is pressed and the player is on the ground, the player jumps
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse); //jumps to the height of jump power
            animator.SetBool("IsJumping", true);
            Debug.Log("Jumped");
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfDead(collision);
    }
    public void CheckIfDead(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isRolling == false && hasRhino == false)
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Enemy" && isRolling == true)
        {
            //Enemy.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Enemy" && hasRhino == true)
        {
            //Enemy.gameObject.SetActive(false);
            //Enemy2.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Rhino")
        {
            hasRhino = true;
            animator.SetBool("IsRhino", true);
            Destroy(Rhino.gameObject);
        }


    }
    void dkRoll()
    {
        if(canDash)
        {
            StartCoroutine(Roll());
        }
    }
    IEnumerator Roll()
    {
        canDash = false;
        
        if (direction == 1)
        {
            rb.velocity = new Vector2(-rollSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(rollSpeed, 0);
        }
        isRolling = true;
        animator.SetBool("IsRolling", true);
        //moveSpeed = rollSpeed;
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        animator.SetBool("IsRolling", false);
        moveSpeed = 5;
        yield return new WaitForSeconds(rollWait);
        canDash = true;

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



