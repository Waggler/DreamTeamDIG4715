using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    public GameObject Player;

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
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfDead(collision);
        //CheckIfBounce(enemyCollision);
    }

    void CheckIfDead(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerRhino == true || collision.gameObject.tag == "Player" && playerRolling == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
