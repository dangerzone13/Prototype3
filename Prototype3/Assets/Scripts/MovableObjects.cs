using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjects : MonoBehaviour 
{
	public GameObject player;
	public GameObject shield;
	public Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//If Player Collides with Box, it will be immovable. If Shield Collides with Box, it will be movable.
	void OnCollisionEnter (Collision col)
	{
		/*if (col.gameObject.tag == "Player") 
		{
			Debug.Log ("Player collides");
			rb.constraints = RigidbodyConstraints.FreezeAll;
		}*/

		Debug.Log("HIT! :" + col.gameObject);
		Debug.Log("HIT! Collider: " + col.collider.gameObject);

		if (col.collider.gameObject.tag == "Shield") 
		{
			Debug.Log ("Shield collides");
			rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
	}

	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "Shield") 
		{
			Debug.Log ("Player goes away");
			rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
	}
}
