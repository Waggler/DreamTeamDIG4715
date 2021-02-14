using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RamEnemy : MonoBehaviour
{

    public AudioClip beaverKill;
    public AudioSource audioSource;

    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("RAM ENEMY");

            audioSource.PlayOneShot(beaverKill, 0.7F);
            //col.gameObject.SetActive(false);
        }
    }
}
