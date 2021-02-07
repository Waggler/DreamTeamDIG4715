using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer; // variable to hold a reference to our SpriteRenderer component
    private void Awake() // This function is called just one time by Unity the moment the component loads
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>(); // get a reference to the SpriteRenderer component on this gameObject
    }

    private void Update()  // This function is called by Unity every frame the component is enabled
    {

        if (Input.GetKeyDown(KeyCode.A)) // if the A key was pressed this frame
        {
            if (mySpriteRenderer != null) // if the variable isn't empty (we have a reference to our SpriteRenderer
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) // if the D key was pressed this frame
        {
            // flip the sprite
            mySpriteRenderer.flipX = false;
        }
    }
}
