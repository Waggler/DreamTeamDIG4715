using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killzone"))
        {
            gameObject.SetActive(false);
            //Debug.Log("Kill Zone Activated");
        }
    }
}