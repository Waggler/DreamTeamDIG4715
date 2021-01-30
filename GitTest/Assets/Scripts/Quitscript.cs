using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitscript : MonoBehaviour
{

    // Quit at any time
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
