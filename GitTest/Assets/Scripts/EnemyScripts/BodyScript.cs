using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public bool dead = false;

    public bool playerRhino;
    public bool playerRolling;
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {
       //playerScript = GameObject.Find("Player").GetComponent<PlayerController>().hasRhino;
    }

    // Update is called once per frame
    void Update()
    {
       playerRhino = GameObject.Find("Player").GetComponent<PlayerController>().hasRhino;
       playerRolling = GameObject.Find("Player").GetComponent<PlayerController>().isRolling;
       
       //transform.parent.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfDead(collision);


        //CheckIfBounce(enemyCollision);
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.GetComponent<PlayerController>().hasRhino == true)
        {
             gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerController>().isRolling == false)
        {
            Debug.Log("Collided wuith player");
            col.gameObject.SetActive(false);
        }
        
        /*if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerController>().hasRhino == false)
        {
            Debug.Log("Collided wuith rhino");
            col.gameObject.SetActive(false);
        }*/
    }


    public void CheckIfDead(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerRhino == true || collision.gameObject.tag == "Player" && playerRolling == true)
        {
            //this.transform.parent.gameObject.SetActive(false);
            //Destroy(transform.parent.gameObject);
            die();
            //Enemy.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("body hit");
        }
        /*
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
        */
        else
        {
            return;
        }
    }


    public void die()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
