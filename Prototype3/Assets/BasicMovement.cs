using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	public float speed = 10.0f;
	public float rotationSpeed = 2.0f;

	public float jumpSpeed = 15.0f;
	public float gravity = 30.0f;

	public float maxHeadRotation = 80.0f;
	public float minHeadRotation = -80.0f;

	public Transform head;

	private float currentHeadRotation = 0;
	private float yVelocity = 0;

	private CharacterController controller;
	private Vector3 moveVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		if (controller.isGrounded)
		{
			Debug.Log ("Grounded");
			print ("Grounded");
			yVelocity = 0;

			if (Input.GetButtonDown("Jump"))
			{
				yVelocity = jumpSpeed;
			}

			moveVelocity = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * speed;
		}

		yVelocity -= gravity * Time.deltaTime;

		transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

		currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);

		head.localRotation = Quaternion.identity;
		head.Rotate(Vector3.left, currentHeadRotation);

		Vector3 velocity = moveVelocity + yVelocity * Vector3.up;

		controller.Move(velocity * Time.deltaTime);
	}
}
