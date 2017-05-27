using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour {
    public float speed;
    public float speed2;
    public bool shieldTouch;
    Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
       // GetComponent<Rigidbody>().AddForce(this.transform.right * speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(this.transform.right * speed);
        if (shieldTouch)
        {
            speed = -20;
            //rb.AddForce(-transform.right * speed);
        }	
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Shield")
        {
            gameObject.tag = "bulletdef";
            shieldTouch = true;
            Debug.Log("Shield touch");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            gameObject.tag = "bulletdef";
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            this.gameObject.tag = "bulletdef";
        }
    }
}
