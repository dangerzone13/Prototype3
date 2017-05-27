using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour {

	GameObject prefab;
	public GameObject shield;
	public GameObject throwPoint;
	public AudioClip shieldThrow;

	AudioSource playerAudio;

	Animator shieldWindUpAnim;

	// Use this for initialization
	void Awake () 
	{
		//playerArmsAnim = playerArms.gameObject.GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		prefab = shield;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			//playerAudio.PlayOneShot(shootAudio);
			//playerArmsAnim.Play("Shoot");
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			GameObject shield = Instantiate(prefab) as GameObject;
			shield.transform.position = throwPoint.transform.position + throwPoint.transform.forward * 1;

			//bullet angle
			shield.transform.rotation = throwPoint.transform.rotation;
			Rigidbody rb = shield.GetComponent<Rigidbody>();
			rb.velocity = throwPoint.transform.forward * 20;
			gameObject.GetComponent<ShieldThrow>().shield = null;
		}
	}
}