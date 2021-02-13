using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfDead(collision);
        //CheckIfBounce(enemyCollision);
    }

    void CheckIfDead(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
            //Enemy.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("head hit");
        }

    }
}
