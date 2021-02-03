using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    //public bool isGrabbed;
    public Transform boxHolder;
    public Transform grabDetect;
    public float rayDist;

    private void Update()
    {

        RaycastHit2D isGrabbed = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(isGrabbed.collider != null && isGrabbed.collider.tag == "Barrel")
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isGrabbed.collider.gameObject.transform.parent = boxHolder;
                isGrabbed.collider.gameObject.transform.position = boxHolder.position;
                isGrabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                isGrabbed.collider.gameObject.transform.parent = null;
                isGrabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

    /*
/*RaycastHit2D hit;
public float distance = 2f;
public Transform holdPoint;
public float throwForce;
// Start is called before the first frame update
void Start()
{

}

// Update is called once per frame
void Update()
{
    if (Input.GetButtonDown("Fire1"))
    {
        if (!isGrabbed)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

            if (hit.collider != null)
            {
                isGrabbed = true;
            }
        }
    }
    else
    {
        isGrabbed = false;
        if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
        }
    }
    if (isGrabbed)
    {
        hit.collider.gameObject.transform.position = holdPoint.position;
    }
}
*/
}
