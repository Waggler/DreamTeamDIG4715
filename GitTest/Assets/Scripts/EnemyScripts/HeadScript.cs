using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update




    void OnTriggerEnter2D(Collider2D collision)
    {
        //CheckIfDead(collision);
        //CheckIfBounce(enemyCollision);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collided w/ player");
            this.gameObject.SetActive(false);
        }
    }


    void CheckIfDead(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Destroy(transform.parent.gameObject);
            //transform.parent.gameObject.SetActive(false);
            //Enemy.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("head hit");
        }

    }
}

