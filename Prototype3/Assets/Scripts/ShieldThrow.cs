using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour {

	GameObject prefab;
	public GameObject shield;
	public GameObject shieldOnPlayer;
	public bool shieldThrown;
	public GameObject throwPoint;

	public static bool throwActive;

	public AudioSource playerAudio;
	public AudioClip shieldCharge;
	public AudioClip shieldThrow;
	public bool canPlaySound = true;

	private Animator anim;

	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public float chargeCounter = 0.0f;

	// Use this for initialization
	void Awake () 
	{
		//playerArmsAnim = playerArms.gameObject.GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		prefab = shield;

		anim = GetComponent<Animator>();

		//shieldThrown = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0))
		{
			//playerArmsAnim.Play("Shoot");

			//Shield Throw Wind Up Bool True
			anim.SetBool ("Throw Wind Up", true);
			throwActive = true;
			//shieldOnPlayer.SetActive (true);

			chargeCounter += 2;

			if ((chargeCounter >= 100) && canPlaySound) 
			{
				Debug.Log ("Shield Throw Charged");
				playerAudio.PlayOneShot (shieldCharge);
				canPlaySound = false;
			} 

			MyCharacterController.speed = 0;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			if (chargeCounter >= 100) 
			{
				playerAudio.PlayOneShot (shieldThrow);
				GameObject shield = Instantiate (prefab) as GameObject;
				shield.transform.position = throwPoint.transform.position + throwPoint.transform.forward;

				//bullet angle
				shield.transform.rotation = shield.transform.rotation;
				Rigidbody rb = shield.GetComponent<Rigidbody> ();
				rb.velocity = throwPoint.transform.forward * 20;
				//shieldThrown = true;
				//shieldOnPlayer.SetActive (false);
				//gameObject.GetComponent<ShieldThrow> ().shield = null;
			}
			//Shield Throw Wind Up Bool False
			anim.SetBool ("Throw Wind Up", false);
			throwActive = false;

			chargeCounter = 0;

			canPlaySound = true;

			shieldOnPlayer.SetActive (false);
			//shieldThrown = true;
		} 

		/*if (!shieldThrow) {
			shieldOnPlayer.SetActive (false);
		}*/

		//if (MyCharacterController.shieldPickUp) 
		if(MyCharacterController.shieldPickUp)
		{
			//StartCoroutine ("ThrowShield");
			shieldOnPlayer.SetActive (true);
			shieldThrown = false;
		} 

		if (!shieldThrown) {
			//shieldOnPlayer.SetActive (true);
		}
	}

	IEnumerator ThrowShield () {
		yield return new WaitForSeconds (0);
		shieldOnPlayer.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		shieldThrown = false;
		StopCoroutine ("ThromShield");

	}

	public void GiveMeShield () {
		//shieldOnPlayer.SetActive (true);
	}
}