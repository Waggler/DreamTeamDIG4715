using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunchScript : MonoBehaviour
{
    public int bananaBunch = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreScript.instance.ChangeScore(bananaBunch);
        }
    }
}

