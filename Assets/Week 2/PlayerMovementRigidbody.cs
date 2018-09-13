using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRigidbody : MonoBehaviour
{
	public float speed = 5;

	private PlayerInput gestureInput;
	private Vector3 targetPosition;
	private bool moving = false;
	private Rigidbody myRigidbody;

	private void Start ()
	{
		gestureInput = GetComponent<PlayerInput>();
		targetPosition = this.transform.position;
		myRigidbody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	private void Update ()
	{
		Tap input = gestureInput.GetInput();

		if (input != null)
		switch (input.Gesture)
		{
				case TapInputGesture.Tap:
					Debug.Log("Input: Tap");

					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(input.originPosition);

					if (Physics.Raycast(ray, out hit))
					{
						targetPosition = hit.point;
						myRigidbody.transform.LookAt(new Vector3(targetPosition.x, 0, targetPosition.z));
						moving = true;
					}

					break;
		}
	}

	private void FixedUpdate()
	{
		if (Vector3.Distance(this.transform.position, targetPosition) > 0.05f)
		{
			myRigidbody.velocity = myRigidbody.transform.forward * speed;
		}
		else if (moving)
		{
			myRigidbody.velocity = Vector3.zero;
			moving = false;
		}
	}
}
