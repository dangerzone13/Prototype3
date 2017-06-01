using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTouch : MonoBehaviour 
{

	public AudioSource playerAudio;
	public AudioClip objects1;
	public AudioClip objects2;

	public bool canPlaySound = true;

	private GameObject target;
	private Vector3 targetPoint;
	private Quaternion targetRotation;
	private float speed = 5.0f;

	// Use this for initialization
	void Start () 
	{
		playerAudio = GetComponent <AudioSource> ();	

		target = GameObject.FindWithTag("Shield Return");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
			targetRotation = (Quaternion.LookRotation(targetPoint, Vector3.up) * Quaternion.Euler(0, 75, 0));
			transform.rotation = (Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f));

			transform.position = Vector3.MoveTowards (transform.position, targetPoint, speed * Time.deltaTime);
		}
	}

	//Colliding with EnviroObjects
	void OnCollisionEnter (Collision col)
	{
		if ((col.gameObject.tag == "EnviroObject") && canPlaySound) 
		{
			playerAudio.PlayOneShot (objects1);
			canPlaySound = false;
			Debug.Log ("Touch1");
		}

		Debug.Log("HIT! :" + col.gameObject);

		if ((col.gameObject.tag == "battery") && canPlaySound) 
		{
			playerAudio.PlayOneShot (objects2);
			canPlaySound = false;
			Debug.Log ("Touch2");
		}
	}

	void OnCollisionExit (Collision col)
	{
		if ((col.gameObject.tag == "EnviroObject") && (canPlaySound = false)) 
		{
			canPlaySound = true;
			Debug.Log ("Touch3");
		}

		if ((col.gameObject.tag == "battery") && (canPlaySound = false)) 
		{
			canPlaySound = true;
			Debug.Log ("Touch4");
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (this.gameObject);
		}
	}

}
