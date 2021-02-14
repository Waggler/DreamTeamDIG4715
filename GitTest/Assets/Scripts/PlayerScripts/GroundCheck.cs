using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject Player;
    public Animator animator;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D()
    { 
    
    }

     
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfGround(collision);

        //CheckIfBounce(enemyCollision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.GetComponent<PlayerController>().isGrounded = false;
    }

    public void CheckIfGround(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
            Player.GetComponent<PlayerController>().isGrounded = true;
            Debug.Log("On Ground");
        }
        else if (collision.gameObject.CompareTag("Enemy")  && collision.transform.GetChild(0).gameObject.CompareTag("Head"))
        {
            //Instantiate(particles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            //particles.gameObject.SetActive(true);
            //particles.Play();
            //Player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 25f), ForceMode2D.Impulse);
            //rb.velocity = Vector2.up * dkJump;
            //.Log("Turn off Enemy");
            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
    }
}
