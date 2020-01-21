using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    //Ref to rigidBody
    public Rigidbody rb;
    public float force = 1000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("z"))
        {
            rb.AddForce(0, 0, force * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -force * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(force * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("q"))
        {
            rb.AddForce(-force * Time.deltaTime, 0, 0);
        }
    }
}
