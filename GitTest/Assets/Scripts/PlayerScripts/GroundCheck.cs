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

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.GetComponent<PlayerController>().isGrounded = false;
    }

    public void CheckIfGround(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Player.GetComponent<PlayerController>().isGrounded = true;
            Debug.Log("On Ground");
        }
        else if (collision.gameObject.tag == "Head")
        {
            Player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
            Debug.Log("Bounce on Enemy");
            Destroy(collision.gameObject);
        }
    }
}
