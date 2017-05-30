using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour 
{
	private GameObject player;
	public float speed;
	public float rotationSpeed = 2.0f;
	public Transform head;
	public bool moving;

	public float maxHeadRotation = 80.0f;
	public float minHeadRotation = -80.0f;
	private float currentHeadRotation = 0;

	private float yVelocity = 0;
	public float jumpSpeed = 5.0f;
	public float gravity = 30.0f;

	public bool aim; 
	public GameObject shield;

	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

		//Set Grounded Anim Bool to True
		anim.SetBool("Grounded", true);


		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = true;
		}

		//Jump Input
		if (Input.GetButtonDown("Jump"))
		{
			yVelocity = jumpSpeed;
		}

		yVelocity -= gravity * Time.deltaTime;

		//Mouse Movement & Head Rotation
		Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
		currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
		head.localRotation = Quaternion.identity;
		head.Rotate(Vector3.left, currentHeadRotation);

		//Character Movement
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(input * speed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));


		//Activating Walk Cycle Animation
		if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) 
		{
			anim.SetBool ("Walking", true);
			Debug.Log ("Vertical");
		} 
		else 
		{
			anim.SetBool ("Walking", false);
		}

		//Shield Block
		// Activate aim by input.
		aim = Input.GetButton("Aim");

		// Player is aiming.
		if (Input.GetButton ("Aim")) 
		{
			//Shield Activates
			shield.SetActive (true);

			//Block Animator Bool set to True
			anim.SetBool ("Blocking", true);

			if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) 
			{
				//Blocking Animator Bool set to True
				anim.SetBool ("Move Blocking", true);
			}
		} 
		else 
		{
			anim.SetBool ("Blocking", false);
			anim.SetBool ("Move Blocking", false);
		}
	}
}
