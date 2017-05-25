using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(this.transform.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shield")
        {
            gameObject.tag = "bulletdef";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "shield")
        {
            gameObject.tag = "bulletdef";
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "shield")
        {
            this.gameObject.tag = "bulletdef";
        }
    }
}
