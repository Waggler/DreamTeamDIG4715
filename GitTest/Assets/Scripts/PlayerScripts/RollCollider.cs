using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is a work in progress, need to first implement roll
public class RollCollider : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    //private float nextRoll = 1f;
    //private float rollDuration = 1f;
    //private float Time = 0.0F;
    //private float rollWait = 1f;
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
        CheckIfAttack(collision);
    }

    public void CheckIfAttack(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Input.GetButton("shift") == true)
        {

            Destroy(collision.gameObject);

            Roll();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //Player.gameObject.SetActive(false);
        }
    }
    IEnumerator Roll()
    {
        yield return new WaitForSeconds(5);
    }
}
