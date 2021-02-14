using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamiController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public float dkSpeed;
    public float dkJump;
    public float dkSprint;
    public float dkWalk;
    public float bounceJump;
    public float RamiSpeed;
    public float RamiJump;
    public GameObject Ram;


    public float timer;
    public float waitTime = 2;
    public float timerReset = 0;


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

    } // END


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveRight = new Vector3(20f, 0f, 0);
        moveLeft = new Vector3(-20f, 0, 0);

        tempVectRight = new Vector3(1000, 0, 0);
        tempVectRight = tempVectRight.normalized * rollSpeed * Time.deltaTime;


        tempVectLeft = new Vector3(-1000, 0, 0);
        tempVectLeft = tempVectLeft.normalized * rollSpeed * Time.deltaTime;
    } // END



    IEnumerator StartRoll()
    {
        yield return new WaitForSeconds(.5f);
        canRoll = false;
        animator.SetBool("IsRolling", false);
        isRolling = false;

    } // END


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (canRoll)
        {
            StartCoroutine(StartRoll());

            if (canRoll)
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

        /*if (Input.GetKeyDown(KeyCode.Space) && DkGrounded())
        {
            float dkJump = 20f;
            float RamiJump = 15;
            if (hasRhino == false)
            {
                rb.velocity = Vector2.up * dkJump;
            }
            else
            {
                rb.velocity = Vector2.up * RamiJump;
            }
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsRhino", false);
            hasRhino = false;

        }
        */
    }
    private void FixedUpdate()
    {


        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A))
        {
            if (hasRhino == false)
            {
                rb.velocity = new Vector2(-dkSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-RamiSpeed, rb.velocity.y);
            }

            animator.SetBool("IsWalking", true);
            direction = 1;
            mySpriteRenderer.flipX = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (hasRhino == false)
                {
                    rb.velocity = new Vector2(+dkSpeed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(+RamiSpeed, rb.velocity.y);
                }
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
    } // END FixedUpdate
}
