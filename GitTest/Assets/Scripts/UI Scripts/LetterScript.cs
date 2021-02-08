using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterScript : MonoBehaviour
{
    public GameObject lK;
    public GameObject lO;
    public GameObject lN;
    public GameObject lG;
    public Image uIK;
    public Image uIO;
    public Image uIN;
    public Image uIG;

    private void OnTriggerEnter2D(Collider2D lK)
    {
        if (lK.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit K!");
            uIK.enabled = true; 
        }
    }
}
