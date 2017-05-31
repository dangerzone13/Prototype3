using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTouch : MonoBehaviour 
{

	public AudioSource playerAudio;
	public AudioClip objects1;
	public AudioClip objects2;

	public bool canPlaySound = true;

	// Use this for initialization
	void Start () 
	{
		playerAudio = GetComponent <AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
			Destroy (this);
		}
	}
}
