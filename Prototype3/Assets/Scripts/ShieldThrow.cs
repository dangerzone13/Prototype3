using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour {

	GameObject prefab;
	public GameObject shield;
	public GameObject throwPoint;
	public AudioClip shieldThrow;
	public static bool throwActive;

	public AudioSource playerAudio;

	private Animator anim;

	// Use this for initialization
	void Awake () 
	{
		//playerArmsAnim = playerArms.gameObject.GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		prefab = shield;

		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			//playerAudio.PlayOneShot(shootAudio);
			//playerArmsAnim.Play("Shoot");

			//Shield Throw Wind Up Bool True
			anim.SetBool ("Throw Wind Up", true);
			throwActive = true;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			GameObject shield = Instantiate(prefab) as GameObject;
			shield.transform.position = throwPoint.transform.position + throwPoint.transform.forward * 1;

			//bullet angle
			shield.transform.rotation = throwPoint.transform.rotation;
			Rigidbody rb = shield.GetComponent<Rigidbody>();
			rb.velocity = throwPoint.transform.forward * 40;
			gameObject.GetComponent<ShieldThrow>().shield = null;

			//Shield Throw Wind Up Bool False
			anim.SetBool ("Throw Wind Up", false);
			throwActive = false;
		}
	}
}