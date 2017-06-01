using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour 
{
	public static float speed = 2f;
	public float rotationSpeed = 2.0f;
    public float raydist;
	public bool moving;

	public float jumpSpeed = 15.5f;
	public float gravity = 30.0f;

	public float maxHeadRotation = 80.0f;
	public float minHeadRotation = -80.0f;

	public Transform head;

	private float currentHeadRotation = 0f;
	private float yVelocity = 0f;

	private CharacterController controller;
	private Vector3 moveVelocity = Vector3.zero;

	public bool aim; 
	public bool shield;

	public AudioSource playerAudio;
	public AudioClip footSteps;
	public bool canPlaySound = true;

	public static bool shieldPickUp;

	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

		//Set Grounded Anim Bool to True
		anim.SetBool("Grounded", true);

		controller = GetComponent<CharacterController>();

		playerAudio = GetComponent<AudioSource>();

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

		Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		yVelocity = 0.0f;
		//Jump Input
		if (Input.GetButtonDown ("Jump")) 
		{
            Vector3 fwd = transform.TransformDirection(Vector3.down);
            //Debug.Log("Jump");
            yVelocity = jumpSpeed;
            anim.SetBool("Grounded", false);
            anim.SetBool("Jump", true);
            if (Physics.Raycast(transform.position, fwd, raydist)) { 
                    Debug.Log("There is something in front of the object!");
            }
      
		} 
		else 
		{
			//Debug.Log ("Not Grounded");
			//anim.SetBool ("Grounded", true);
			anim.SetBool ("Jump", false);
		}
	
		moveVelocity = transform.TransformDirection (new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"))) * speed;

		yVelocity -= gravity * Time.deltaTime;

		//Mouse Movement & Head Rotation
		transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
		currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
		head.localRotation = Quaternion.identity;
		head.Rotate(Vector3.left, currentHeadRotation);

		//Character Movement
		Vector3 velocity = moveVelocity + yVelocity * Vector3.up;
		controller.Move(velocity * Time.deltaTime);
		//Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		//gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(input * speed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));

		//Play Footsteps when player moves
		if (controller.velocity.sqrMagnitude > 0 && (moveVelocity.x != 0 || moveVelocity.y != 0))
		{
			//Debug.Log ("Play Footsteps");
			playerAudio.PlayOneShot (footSteps);
		}

		//Activating Walk Cycle Animation
		if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) 
		{
			anim.SetBool ("Walking", true);
			moving = true;
		} 
		else 
		{
			anim.SetBool ("Walking", false);
			moving = false;
		}

		//Animator Bool for Block Movement
		if (moving) 
		{
			anim.SetBool ("Move Blocking", true);
		}
		else 
		{
			anim.SetBool ("Move Blocking", false);
		}

		//Shield Block
		aim = Input.GetButton("Aim");

		// Player is aiming.
		if (Input.GetButton ("Aim")) 
		{
			//Block Animator Bool set to True
			anim.SetBool ("Blocking", true);
		} 
		else 
		{
			anim.SetBool ("Blocking", false);
			anim.SetBool ("Move Blocking", false);
		}
			
		if (aim) 
		{
			speed = 0.9f;
		} 
		else 
		{
			speed = 2.0f;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ground") 
		{
            anim.SetBool("Grounded", true);
            Debug.Log ("GROUND MOTHERFUCKER");
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Shield Projectile Prefab") 
		{
			shieldPickUp = true;
		}
        if (col.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", true);
            Debug.Log("GROUND MOTHERFUCKER");
        }
    }
}
