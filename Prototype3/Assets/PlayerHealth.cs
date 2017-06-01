using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int PlayerMaxHealth = 100;
	public int PlayerCurHealth = 100;

	public CharacterController controller;

	public GameObject playerMesh;
	public AudioClip deathAudio;

	public bool deathSoundPlayed = false;

	AudioSource enemyOneAudio;

	Animator playerAnim;
	NavMeshAgent nav;

	// Ragdoll Variables: Roller Enemy

	// COMPONENT GUIDE:

	// [RIDIGBODY COMPONENT] | [ENEMY MIXAMO JOINT OBJECT]
	// Pelvis/Root  --> Hips
	// Left Hip     --> LeftUpLeg
	// Left Knee    --> Left Leg
	// Right Hip    --> RightUpLeg
	// Right Knee   --> RightLeg
	// Left Arm     --> LeftArm
	// Left Elbow   --> LeftForeArm
	// Right Arm    --> RightArm
	// Right Elbow  --> RightForeArm
	// Middle Spine --> Spine2
	// Head         --> Head

	public Rigidbody ragPelvis;
	public Rigidbody ragLeftHip;
	public Rigidbody ragLeftKnee;
	public Rigidbody ragRightHip;
	public Rigidbody ragRightKnee;
	public Rigidbody ragLeftArm;
	public Rigidbody ragLeftElbow;
	public Rigidbody ragRightArm;
	public Rigidbody ragRightElbow;
	public Rigidbody ragMiddleSpine;
	public Rigidbody ragHead;
	public float ragTimer;

	void Start ()
	{

	}
	// Use this for initialization
	void Awake () {
		playerAnim = GetComponent<Animator>();

		enemyOneAudio = GetComponent<AudioSource>();

		ragPelvis.isKinematic = true;
		ragLeftHip.isKinematic = true;
		ragLeftKnee.isKinematic = true;
		ragRightHip.isKinematic = true;
		ragRightKnee.isKinematic = true;
		ragLeftArm.isKinematic = true;
		ragLeftElbow.isKinematic = true;
		ragRightArm.isKinematic = true;
		ragRightElbow.isKinematic = true;
		ragMiddleSpine.isKinematic = true;
		ragHead.isKinematic = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (PlayerCurHealth <= 0)
		{
			StartCoroutine("Death");  

			if (deathSoundPlayed == false)
			{
				//enemyOneAudio.clip = deathAudio;
				enemyOneAudio.PlayOneShot(deathAudio);
				deathSoundPlayed = true;
			}
		}
	}

	IEnumerator Death ()
	{
		//playerAnim.Play("Death");
		//playerMesh.GetComponent<CapsuleCollider>().enabled = false;
		//GetComponent<SphereCollider>().enabled = false;

		yield return new WaitForSeconds(ragTimer); // Keep value low to allow few frames of death animation

		ragPelvis.isKinematic = false;
		ragLeftHip.isKinematic = false;
		ragLeftKnee.isKinematic = false;
		ragRightHip.isKinematic = false;
		ragRightKnee.isKinematic = false;
		ragLeftArm.isKinematic = false;
		ragLeftElbow.isKinematic = false;
		ragRightArm.isKinematic = false;
		ragRightElbow.isKinematic = false;
		ragMiddleSpine.isKinematic = false;
		ragHead.isKinematic = false;

		playerAnim.enabled = false; // Required to fully apply RagDoll physics
	
		//yield return new WaitForSeconds(3);
		//Destroy(gameObject);

		controller.enabled = false;
		GetComponent<CapsuleCollider> ().enabled = true;
		GetComponent<MyCharacterController> ().enabled = false;

		yield return new WaitForSeconds (5);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "bullet") 
		{
            Debug.Log("Oh noee");
			PlayerCurHealth = 0;
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Debug.Log("Oh noee");
            PlayerCurHealth = 0;
        }
    }
}
