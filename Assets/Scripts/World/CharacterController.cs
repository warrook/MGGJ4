using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float speed = 30;
    Rigidbody rigidbody;

	//Deceleration and damping variables for Vector3.SmoothDamp
	private Vector3 dampingHz;
	private Vector3 dampingVt;
	private float deceleration = 0.1f; //time in seconds to come to a stop

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		//Get input and total (desired) movement direction
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

		rigidbody.AddForce(movement * speed * 100);

		//This prevents gravity from working properly
		if (horizontalInput == 0)
		{
			var velocity = rigidbody.velocity;
			rigidbody.velocity = Vector3.SmoothDamp(velocity, Vector3.Project(velocity, transform.forward), ref dampingHz, deceleration);
		}
		if (verticalInput == 0)
		{
			var velocity = rigidbody.velocity;
			rigidbody.velocity = Vector3.SmoothDamp(velocity, Vector3.Project(velocity, transform.right), ref dampingVt, deceleration);
		}
	}
}
