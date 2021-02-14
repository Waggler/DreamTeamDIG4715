using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public float dkSpeed;
    public float dkJump;
    public float dkSprint;
    public float dkWalk;
    public float timer;
    public float waitTime = 2;
    public float timerReset= 0;


    public float jumpPower = 20f; //determines height of jump
    public float moveSpeed = 5f; //determines move speed
    public float sprintSpeed = 10f; //determines move speed when sprinting
    public float crouchSpeed = 2f; ////determines move speed when crouching 

    public bool isRolling = false;

    public bool canDash = true;
    public float rollingTime;
    public float rollSpeed;
    public float rollWait = 2f;
    public float rollTimer = 0.5f;

    private int direction;

    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Rhino;

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

    public Rigidbody2D rb;

    public Animator animator;


    float horizontalMove = 0f;
    private SpriteRenderer mySpriteRenderer; // variable to hold a reference to our SpriteRenderer component

    private BoxCollider2D boxCollider2d;

    public Vector3 moveRight;
    public Vector3 moveLeft;
    Vector3 tempVectRight;
    Vector3 tempVectLeft;
    private bool canRoll = false;




    private void Awake() // This function is called just one time by Unity the moment the component loads
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();// get a reference to the SpriteRenderer component on this gameObject
        boxCollider2d = GetComponent<BoxCollider2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveRight = new Vector3(20f, 0f, 0);
        moveLeft = new Vector3(-20f, 0, 0);

        tempVectRight = new Vector3(1000, 0, 0);
        tempVectRight = tempVectRight.normalized * rollSpeed * Time.deltaTime;
        
        
        tempVectLeft = new Vector3(-1000, 0, 0);
        tempVectLeft = tempVectLeft.normalized * rollSpeed * Time.deltaTime;
    }

    /*
    public void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        float xForce = xInput * dkSpeed * Time.deltaTime;

        Vector2 force = new Vector2(xForce, 0);

        rb.AddForce(force);
        Debug.Log(rb.velocity);
    }
    */



    IEnumerator StartRoll()
    {
        yield return new WaitForSeconds(.5f);
        canRoll = false;
        animator.SetBool("IsRolling", false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (canRoll)
        {
            //Vector3 tempVect = new Vector3(-1000, 0, 0);
            //tempVect = tempVect.normalized * rollSpeed * Time.deltaTime;

            //Find which direction he needs to go
            //Replace Vector3(-1000) with the appropriate Vector Direction

            StartCoroutine(StartRoll());

            if(canRoll)
            {

                if (direction == 1)
                {
                    rb.MovePosition(transform.position + tempVectLeft);
                }
                else if (direction == 2)
                {
                    rb.MovePosition(transform.position + tempVectRight);
                }
                
            }
            else 
            {
                return;
            }


        }

        if (Input.GetKeyDown(KeyCode.Space) && DkGrounded())
        {
            float dkJump = 20f;
            rb.velocity = Vector2.up * dkJump;
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsRhino", false);
            hasRhino = false;

        }
        else if (Input.GetKeyDown(KeyCode.R) && DkGrounded() && hasRhino == false)
        {
            if (timer > waitTime)
            {
                if (direction == 1)
                {

                    canRoll = true;
                    //StartCoroutine(StartRoll());
                    isRolling = true;
                    animator.SetBool("IsRolling", true);
                    canDash = false;
                }
                else if (direction == 2)
                {
                    canRoll = true;
                    isRolling = true;
                    animator.SetBool("IsRolling", true);
                    canDash = false;

                    
                    //rb.AddForce(moveRight  * 3f);
                    //this.transform.Translate(moveRight * Time.deltaTime);
                }

                //canDash = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && DkGrounded())
        {
            dkSpeed = dkSprint;
            animator.SetBool("IsSprinting", true);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space) && DkGrounded() && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) == true)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            dkSpeed = dkWalk;
            animator.SetBool("IsSprinting", false);
        }

        /*if (Input.GetKey(KeyCode.A))
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

        */
    }
    private void FixedUpdate()
    {
        

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-dkSpeed, rb.velocity.y);
            animator.SetBool("IsWalking", true);
            direction = 1;
            mySpriteRenderer.flipX = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(+dkSpeed, rb.velocity.y);
                animator.SetBool("IsWalking", true);
                direction = 2;
                mySpriteRenderer.flipX = false;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                animator.SetBool("IsWalking", false);
            }
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
    private bool DkGrounded()
    {
        float extraHeightText = 0.5f;
        //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, groundMask);
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            if (raycastHit.transform.gameObject.layer == groundMask)
            {
                animator.SetBool("IsJumping", false);
            }
            rayColor = Color.green;

        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText));
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText));
        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y), Vector2.right * (boxCollider2d.bounds.extents.x));
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    /*
     * void dkRoll()
    {
        if (canDash)
        {
            StartCoroutine(Roll());
        }
    }
    IEnumerator Roll()
    {
        

        if (direction == 1)
        {
            //rb.velocity = new Vector2(-rollSpeed, 0);
            //rb.velocity = new Vector2(rollSpeed, rb.velocity.y);
            
            
            //rb.AddForce(moveRight * rollSpeed);
        }
        else
        {
            //rb.velocity = new Vector2(rollSpeed, 0);
            rb.AddForce(moveLeft * rollSpeed);
            
            //rb.velocity = new Vector2(-rollSpeed, rb.velocity.y);
        }
        isRolling = true;
        animator.SetBool("IsRolling", true);

        //moveSpeed = rollSpeed;
        canDash = false;
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        
        animator.SetBool("IsRolling", false);
        //moveSpeed = 5;
        
        yield return new WaitForSeconds(rollWait);
        canDash = true;

    }
    */


    /*
    void Jump() //method with Jump and Ground check
    {
        if(Input.GetKeyDown(KeyCode.Space) && DkGrounded())
        {
            float dkJump = 15f;
            rb.velocity = Vector2.up * dkJump;
        }*/


    /*if (Input.GetButtonDown("Jump") && isGrounded == true) //if the jump button is pressed and the player is on the ground, the player jumps
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse); //jumps to the height of jump power
        animator.SetBool("IsJumping", true);
        Debug.Log("Jumped");
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



