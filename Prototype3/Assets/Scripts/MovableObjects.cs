using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjects : MonoBehaviour 
{
	Rigidbody rb;
	public bool shieldTouch;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody>();
		//rb.constraints = RigidbodyConstraints.FreezeAll;
        //rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (!shieldTouch) 
		{
			//rb.constraints = RigidbodyConstraints.FreezeAll;
			rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezeRotation;
		}

		if (shieldTouch)
		{
			rb.constraints = RigidbodyConstraints.None;
			rb.constraints = RigidbodyConstraints.FreezeRotation;
		}
	}

	//If Player Collides with Box, it will be immovable. If Shield Collides with Box, it will be movable.
	void OnCollisionStay (Collision col)
	{
		if (col.collider.gameObject.tag == "Shield") 
		{
			shieldTouch = true;
			Debug.Log ("Shield collides");
		} 
		else 
		{
			shieldTouch = false;
		}

	}

	/*void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "Shield") 
		{
			shieldTouch = false;
			Debug.Log ("Player goes away");
        }
	}*/
}
