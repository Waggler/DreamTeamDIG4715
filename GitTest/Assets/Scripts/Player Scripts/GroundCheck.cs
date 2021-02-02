using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfGround(collision);
        //CheckIfBounce(enemyCollision);
    }
    /*
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerController>().isGrounded = false;
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.GetComponent<PlayerController>().isGrounded = false;
    }

    public void CheckIfGround(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Player.GetComponent<PlayerController>().isGrounded = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
                Player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100f), ForceMode2D.Impulse);
                Debug.Log("Bounce on Enemy");
                Destroy(collision.gameObject);
        }
    }
}
