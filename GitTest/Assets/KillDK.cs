using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Kill Player");
            col.transform.parent.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
