using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortrap : MonoBehaviour {
    public float maxpos;
    private float minpos;
    private float newmax;
    public float speed;

    public bool open;
    public bool stopped;
	
    // Use this for initialization
	void Start () {
        open = false;
        minpos = transform.position.x;
        newmax = minpos + maxpos;
        stopped = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (open == true && transform.position.x >= minpos && stopped == false)
        {
            transform.position += Vector3.left * Time.deltaTime;
            if (transform.position.x <= minpos)
            {
                open = false;
            }
        }

        if (open == false && transform.position.x <= newmax && stopped == false)
        {
            transform.position += Vector3.right * Time.deltaTime;
           if (transform.position.x >= newmax)
           {
               open = true;
           }
        }
   }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Shield")
        {
            stopped = true;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.collider.gameObject.tag == "Shield")
        {
            stopped = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.collider.gameObject.tag == "Shield")
        {
            stopped = false;
        }
    }

}
